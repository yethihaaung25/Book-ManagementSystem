using BooksApi.Models;

namespace BooksApi.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<List<BooksModel>> GetAllBooksAsync();
        Task<BooksModel?> GetBookByIdAsync(Guid id);
        Task<BooksModel> AddBookAsync(BooksModel book);
        Task<BooksModel?> UpdateBookAsync(Guid id, BooksModel book);
        Task<bool> DeleteBookAsync(Guid id);
    }
}
