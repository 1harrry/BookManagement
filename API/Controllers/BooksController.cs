using Microsoft.AspNetCore.Mvc;
using API.Services;
using Domain.DTOs;
using API.Data;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ApplicationDbContext _context;

        public BooksController(IBookService bookService, ApplicationDbContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        // Get all books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // Get a book by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Add a new book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBookAsync(bookDTO);
                return CreatedAtAction(nameof(GetBook), new { id = bookDTO.Id }, bookDTO);
            }
            return BadRequest(ModelState);
        }

        // Update an existing book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDTO)
        {
            if (ModelState.IsValid)
            {
                await _bookService.UpdateBookAsync(id, bookDTO);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // Delete a book
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            var summary = await _bookService.GetDashboardSummaryAsync();
            return Ok(summary);
        }
    }
}
