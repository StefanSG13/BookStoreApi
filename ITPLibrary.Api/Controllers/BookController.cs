using ITPLibrary.Api.Core.Dtos;
using ITPLibrary.Api.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITPLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _books;

        public BookController(IBookService books)
        {
            _books = books;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetAll()
        {
            return _books.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById([FromRoute]int id)
        {
            try
            {
                var result = _books.GetFirstOrDefault(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, BookDto bookDto)
        {
            if (id != bookDto.BookId)
            {
                return BadRequest();
            }

            var book = _books.GetFirstOrDefault(id);
            if (book == null)
            {
                return NotFound();
            }

            _books.Update(bookDto);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> BookPost(BookDto book)
        {

            _books.Add(book);
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (_books.GetFirstOrDefault(id) == null)
            {
                return NotFound();
            }
            _books.Delete(id);
            return Ok();
        }
    }
}
