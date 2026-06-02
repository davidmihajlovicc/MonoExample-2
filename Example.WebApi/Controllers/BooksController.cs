using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IList<Book> books = new List<Book>{
            new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", ReleaseDate = DateOnly.FromDateTime(DateTime.Now), PageCount = 100, ISBN = "1234567890", Authors = new List<Author> { new Author{Id = 1, FirstName = "JK", LastName = "Rowling", BirthDate = DateOnly.FromDateTime(DateTime.Now)}, } },
            new Book { Id = 2, Title = "The Shining", ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), PageCount = 200, ISBN = "0987654321", Authors = new List<Author> { new Author{Id = 2, FirstName = "Steven", LastName = "King", BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)) } } },
            new Book { Id = 3, Title = "To Kill a Mockingbird", ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), PageCount = 300, ISBN = "1122334455", Authors = new List<Author> { new Author{Id = 3, FirstName = "Jane", LastName = "Doe", BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)) } } },
            new Book { Id = 4, Title = "1984", ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), PageCount = 400, ISBN = "5566778899", Authors = new List<Author> { new Author{Id = 4, FirstName = "Jane", LastName = "Smith", BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)) } , new Author{Id = 4, FirstName = "Patrick", LastName = "Jane", BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)) } } },
            new Book { Id = 5, Title = "The Great Gatsby", ReleaseDate = DateOnly.FromDateTime(DateTime.Now.AddDays(4)), PageCount = 500, ISBN = "6677889900", Authors = new List<Author> { new Author{Id = 5, FirstName = "John", LastName = "Doe", BirthDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)) } } }
        };


        [HttpGet(Name = "GetBooks")]
        public IActionResult Get([FromQuery] int id = 0, [FromQuery] string title = "", [FromQuery] string authorName = "", [FromQuery] string authorLastName = "")
        {

            IEnumerable<Book> query = books;

            if (id != 0) {
                query= books.Where(b => b.Id == id);
            }
            if (title != "")
            {
                query = books.Where(b => b.Title == title);
            }
            if (authorName != "") {
                query = books.Where(b => b.Authors.Any(a => a.FirstName == authorName));
            }
            if(authorLastName != "") {
                query = books.Where(b => b.Authors.Any(a => a.LastName == authorLastName));
            }
            if (query != null)
            {
                return Ok(query.ToList());
            }
            return NotFound();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost(Name = "AddBook")]
        public IActionResult Post([FromBody] Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            if(book != null)
            {
                books.Add(book);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}", Name = "UpdateBook")]
        public IActionResult Put(int id, [FromBody] Book book) {

            Book bookToUpdate = books.FirstOrDefault(b => b.Id == id);
            if (book != null && bookToUpdate != null)
            {
                bookToUpdate.ReleaseDate = book.ReleaseDate;
                bookToUpdate.PageCount = book.PageCount;
                bookToUpdate.ISBN = book.ISBN;
                return Ok();
            }
            else if(bookToUpdate == null)
            {
                return NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("{id}", Name = "DeleteBook")]
        public IActionResult Delete(int id) {

            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                return Ok();

            }
            return NotFound();

        }

        [HttpPost("AddBookFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Book book)
        {
            Book newBook = new Book { Id = book.Id, ReleaseDate = book.ReleaseDate, PageCount = book.PageCount, ISBN = book.ISBN };
            if(newBook != null)
            {
                books.Add(newBook);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFromQuery")]
        public IActionResult GetFromQuery([FromQuery] int id) {

            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }


    }
}
