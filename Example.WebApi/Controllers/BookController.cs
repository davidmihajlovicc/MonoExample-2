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
        public async Task<IActionResult> GetAsync(string title = "", string ISBN = "", string authorName = "", string authorLastName = "")
        {

            BookFilter filter = new BookFilter { Title = title, ISBN = ISBN, AuthorName = authorName, AuthorLastName = authorLastName };
            BookService bookService = new BookService();
            IList<Book>? books = await bookService.GetAsync(filter);
            if (books != null) {
                return Ok(books);
            }
            return BadRequest();

            
        }

        [HttpPost(Name = "AddBook")]
        public async Task<IActionResult> PostAsync([FromBody] Book book)
        {
            BookService bookService = new BookService();
            bool postBook = await bookService.PostBookAsync(book);
            if (postBook) {
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Book book) {

            BookService bookService = new BookService();
            bool putBook = await bookService.PutAsync(id, book);
            if (putBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public async Task<IActionResult> DeleteAsync(int id) {

            BookService bookService = new BookService();
            bool deleteBook = await bookService.DeleteAsync(id);
            if (deleteBook)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost("AddBookFromQuery")]
        public async Task<IActionResult> PostFromQueryAsync([FromQuery] Book book)
        {

            BookService bookService = new BookService();
            bool postBook = await bookService.PostBookAsync(book);
            if (postBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFromQuery")]
        public async  Task<IActionResult> GetFromQueryAsync([FromQuery] int id) {

            BookService bookService = new BookService();
            Book? book = await bookService.GetBookAsync(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest();
        }


    }
}
