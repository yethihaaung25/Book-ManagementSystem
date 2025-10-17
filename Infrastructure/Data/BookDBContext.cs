using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Data
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options) { }
        public DbSet<BooksModel> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksModel>()
                .Property(b => b.CategoryId)
                .HasConversion<int>();
        }
    } 
}
