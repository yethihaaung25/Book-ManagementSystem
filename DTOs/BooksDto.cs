using BooksApi.Models;

namespace BooksApi.DTOs
{
    public class BooksDto
    {
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public string CategoryId { get; set; }
    }
}
