using BooksApi.Models;

namespace BooksApi.Infrastructure.Helper
{
    public class BookCategoryHelper
    {
        public static BookCategory ConvertCategory(string? input)
        {
            var result = input?.Trim().ToLower() switch
            {
                "0" => BookCategory.Horror,
                "1" => BookCategory.Scifi,
                "2" => BookCategory.Romance,
                _ => BookCategory.Other
            };

            return result;
        }

        public static string ConvertCategoryToString(BookCategory category)
        {
            return category switch
            {
                BookCategory.Horror => "Horror",
                BookCategory.Scifi => "Sci-Fi",
                BookCategory.Romance => "Romance",
                _ => "Other"
            };
        }
    }
}
