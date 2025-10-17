using BooksApi.DTOs;
using BooksApi.Models;

namespace BooksApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<IList<BooksDto>> GetAllBooksAsync();
        Task<BooksDto?> GetBookByIdAsync(Guid id);
        Task<BooksDto> CreateBookAsync(BooksDto book);
        Task<BooksDto?> UpdateBookAsync(Guid id, BooksDto book);
        Task<bool> DeleteBookAsync(Guid id);
    }
}
