using Microsoft.AspNetCore.Mvc;
using System.Text;
using Example.Model;
using Example.Service;
using Example.Common;

namespace Example.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        

        [HttpGet(Name = "GetBooks")]
        public IActionResult Get([FromQuery] BookFilter filter)
        {

            BookService bookService = new BookService();
            IList<Book>? books = bookService.Get(filter);
            if (books != null) {
                return Ok(books);
            }
            return BadRequest();

            
        }

        [HttpPost(Name = "AddBook")]
        public IActionResult Post([FromBody] Book book)
        {
            BookService bookService = new BookService();
            bool postBook = bookService.PostBook(book);
            if (postBook) {
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public IActionResult Put(int id, [FromBody] Book book) {

            BookService bookService = new BookService();
            bool putBook = bookService.Put(id, book);
            if (putBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public IActionResult Delete(int id) {

            BookService bookService = new BookService();
            bool deleteBook = bookService.Delete(id);
            if (deleteBook)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost("AddBookFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Book book)
        {

            BookService bookService = new BookService();
            bool postBook = bookService.PostBook(book);
            if (postBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFromQuery")]
        public IActionResult GetFromQuery([FromQuery] int id) {

            BookService bookService = new BookService();
            Book? book = bookService.GetBook(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }


    }
}
