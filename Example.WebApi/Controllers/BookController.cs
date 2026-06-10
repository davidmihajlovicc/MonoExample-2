using Microsoft.AspNetCore.Mvc;
using System.Text;
using Example.Model;
using Example.Service;
using Example.Common;
using Example.Service.Common;
using AutoMapper;
using Example.Model.DTO;
using Example.Model.Domain;

namespace Example.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private IBookService bookService;

        public IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper) {
            this.bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<IActionResult> GetAsync(string title = "", string ISBN = "", string authorName = "", string authorLastName = "")
        {

            BookFilter filter = new BookFilter { Title = title, ISBN = ISBN, AuthorName = authorName, AuthorLastName = authorLastName };
            IList<Book>? books = await bookService.GetAsync(filter);
            if (books != null) {
                return Ok(_mapper.Map<List<GetBookDto>>(books));
            }
            return BadRequest();

            
        }

        [HttpPost(Name = "AddBook")]
        public async Task<IActionResult> PostAsync([FromBody] AddBookDto book)
        {
            bool postBook = await bookService.PostBookAsync(_mapper.Map<Book>(book));
            if (postBook) {
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Book book) {

            bool putBook = await bookService.PutAsync(id, book);
            if (putBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public async Task<IActionResult> DeleteAsync(int id) {

            bool deleteBook = await bookService.DeleteAsync(id);
            if (deleteBook)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpPost("AddBookFromQuery")]
        public async Task<IActionResult> PostFromQueryAsync([FromQuery] AddBookDto book)
        {

            bool postBook = await bookService.PostBookAsync(_mapper.Map<Book>(book));
            if (postBook)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFromQuery")]
        public async  Task<IActionResult> GetFromQueryAsync([FromQuery] int id) {

            Book? book = await bookService.GetBookAsync(id);
            if (book != null)
            {
                return Ok(_mapper.Map<GetBookDto>(book));
            }
            return BadRequest();
        }


    }
}
