using System.ComponentModel.DataAnnotations;

namespace BooksApi.Models
{
    public class BooksModel : BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public BookCategory CategoryId { get; set; }
    }
}
