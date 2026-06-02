using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IList<Book> books = new List<Book>{
            new Book { Id = 1, ReleaseDate = DateOnly.FromDateTime(DateTime.Now), PageCount = 100, ISBN = "1234567890" },
            new Book { Id = 2, ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), PageCount = 200, ISBN = "0987654321" },
            new Book { Id = 3, ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), PageCount = 300, ISBN = "1122334455" },
            new Book { Id = 4, ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), PageCount = 400, ISBN = "5566778899" },
            new Book { Id = 5, ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(4)), PageCount = 500, ISBN = "6677889900" }
        };


        [HttpGet(Name = "GetBooks")]
        public IList<Book> Get()
        {
            if(books != null)
            {
                return books.ToArray();
            }
            return Array.Empty<Book>();


        }

        [HttpGet("{id}", Name = "GetBook")]
        public Book Get(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        [HttpPost(Name = "AddBook")]
        public bool Post([FromBody] Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            if(book != null)
            {
                books.Add(book);
                return true;
            }
            return false;
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public bool Put(int id, [FromBody] Book book) {

            Book bookToUpdate = books.FirstOrDefault(b => b.Id == id);
            if (book != null && bookToUpdate != null)
            {
                bookToUpdate.ReleaseDate = book.ReleaseDate;
                bookToUpdate.PageCount = book.PageCount;
                bookToUpdate.ISBN = book.ISBN;
                return true;
            }
            return false;

        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public bool Delete(int id) {

            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                return true;
            }
            return false;

        }

        [HttpPost("AddBookFromQuery")]
        public bool PostFromQuery([FromQuery] Book book)
        {
            Book newBook = new Book { Id = book.Id, ReleaseDate = book.ReleaseDate, PageCount = book.PageCount, ISBN = book.ISBN };
            if(newBook != null)
            {
                books.Add(newBook);
                return true;
            }
            return false;
        }

        [HttpGet("GetFromQuery")]
        public Book GetFromQuery([FromQuery] int id) {

            return books.FirstOrDefault(b => b.Id == id);
            
        }


    }
}
