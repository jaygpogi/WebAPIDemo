using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;
using WebAPIDemo.ViewModels;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;   
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookView>>> GetBooks(int page, int size, string filter = null)
        {
            return Ok(await _bookRepository.GetBooks(filter, page, size)); 
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookView>> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int? id, UpsertBook upsertBook)
        {
            await _bookRepository.UpsertBook(id, upsertBook);
            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookView>> PostBook(UpsertBook upsertBook)
        {
            var bookView = await _bookRepository.UpsertBook(null, upsertBook);
            return CreatedAtAction("GetBook", new { id = bookView.Id }, bookView);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookRepository.DeleteBook(id);
            return NoContent();
        }
    }
}
