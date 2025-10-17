using BooksApi.Infrastructure.Data;
using BooksApi.Models;
using BooksApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _context;
        public BookRepository(BookDBContext context)
        {
            _context = context;
        }

        public async Task<BooksModel> AddBookAsync(BooksModel book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(Guid id)
        {
            var checkBook = await _context.Books.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (checkBook == null)
                return false;

            checkBook.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<List<BooksModel>> GetAllBooksAsync()
        {
            var allBooks = await _context.Books.Where(x => !x.IsDeleted).ToListAsync();
            return allBooks;
        }

        public async Task<BooksModel?> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            return book;
        }

        public async Task<BooksModel?> UpdateBookAsync(Guid id, BooksModel book)
        {
            var checkBook = await _context.Books.Where(x => x.Id == id && !x.IsDeleted).FirstOrDefaultAsync();
            if (checkBook == null)
                return null;

            checkBook.Title = book.Title;
            checkBook.Author = book.Author;
            checkBook.PublishedDate = book.PublishedDate;
            checkBook.CategoryId = book.CategoryId;
            checkBook.UpdatedAt = DateTime.Now;

            _context.Books.Update(checkBook);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
