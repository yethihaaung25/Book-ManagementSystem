using BooksApi.DTOs;
using BooksApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(new { Status = true, StatusCode = StatusCodes.Status200OK, Data = books });
        }

        [HttpGet("GetBookById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book is null)
                return NotFound(new { Status = false, StatusCode = StatusCodes.Status404NotFound, Data = "Book is not found." });

            return Ok(new { Status = true, StatusCode = StatusCodes.Status200OK, Data = book });
        }

        [HttpPost("CreateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] BooksDto bookDto)
        {
            var createdBook = await _bookService.CreateBookAsync(bookDto);
            return Ok(new { Status = true, StatusCode = StatusCodes.Status200OK, Data = createdBook });
        }

        [HttpPut("UpdateBook/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] BooksDto bookDto)
        {
            var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);
            if (updatedBook is null)
                return NotFound(new { Status = updatedBook, StatusCode = StatusCodes.Status404NotFound, Data = "Book is not found." });

            return Ok(new { Status = updatedBook, StatusCode = StatusCodes.Status200OK, Data = "Book updated successfully." });
        }

        [HttpDelete("DeleteBook/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _bookService.DeleteBookAsync(id);
            if (!isDeleted)
                return NotFound(new { Status = isDeleted, StatusCode = StatusCodes.Status404NotFound, Data = "Book is not found." });

            return Ok(new { Status = isDeleted, StatusCode = StatusCodes.Status200OK, Data = "Book deleted successfully." });
        }
    }
}
