using bookapi.Model;
using bookapi.Repositories;
using bookapi.Service;
using Microsoft.AspNetCore.Mvc;

namespace bookapi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public IBookService bookService; 
        public BookController(IBookRepository bookRepository, IBookService bookService)
        {
            _bookRepository = bookRepository;
            this.bookService = bookService;
        }

        [HttpGet]
        public  IEnumerable<Book> GetBooks()
        {
            return  _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public  ActionResult PostBooks([FromBody] employees organization)
        {
            var newBook = bookService.Addemployees(organization);
            if (newBook)
            { 
                return Ok(new Result()
                {
                    result = "Success",
                    message = "Organization Created"
                });
            }
            else
                return BadRequest("Failed to Create Organization");
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookRepository.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}