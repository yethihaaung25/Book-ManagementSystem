using BooksApi.DTOs;
using BooksApi.Infrastructure.Helper;
using BooksApi.Models;
using BooksApi.Repositories.Interfaces;
using BooksApi.Services.Interfaces;

namespace BooksApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<BooksDto> CreateBookAsync(BooksDto bookDto)
        {
            var book = new BooksModel
            {
                Id = Guid.NewGuid(),
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishedDate = bookDto.PublishedDate,
                CategoryId = BookCategoryHelper.ConvertCategory(bookDto.CategoryId.ToString()),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _logger.LogInformation($"Creating a new book : {book.Title}.");
            var response = await _bookRepository.AddBookAsync(book);
            return bookDto;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var response = await _bookRepository.DeleteBookAsync(id);
            _logger.LogInformation($"Book : {id} has been deleted.");
            return response;
        }

        public async Task<IList<BooksDto>> GetAllBooksAsync()
        {
            var response = await _bookRepository.GetAllBooksAsync();
            var booksList = response.Select(book => new BooksDto
            {
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate,
                CategoryId = BookCategoryHelper.ConvertCategoryToString(book.CategoryId),
            }).ToList();

            return booksList;
        }

        public async Task<BooksDto?> GetBookByIdAsync(Guid id)
        {
            var response = await _bookRepository.GetBookByIdAsync(id);
            var booksDto = new BooksDto
            {
                Title = response.Title,
                Author = response.Author,
                PublishedDate = response.PublishedDate,
                CategoryId = BookCategoryHelper.ConvertCategoryToString(response.CategoryId),
            };

            return booksDto;
        }

        public async Task<BooksDto?> UpdateBookAsync(Guid id, BooksDto bookDto)
        {
            var book = new BooksModel
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishedDate = bookDto.PublishedDate,
                CategoryId = BookCategoryHelper.ConvertCategory(bookDto.CategoryId.ToString()),
                UpdatedAt = DateTime.Now
            };
            var response = await _bookRepository.UpdateBookAsync(id, book);
            if(response is null)
                return null;
            _logger.LogInformation($"Book : {id} has been updated.");
            return bookDto;
        }
    }
}
