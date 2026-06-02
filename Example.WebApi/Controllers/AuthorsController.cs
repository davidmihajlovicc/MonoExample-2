using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthorsController: ControllerBase
    {


        IList<Author> authors = new List<Author>()
        {
            new Author() { Id = 1, FirstName = "JK", LastName = "Rowling", BirthDate = new DateOnly(1965, 7, 31) },
            new Author() { Id = 2, FirstName = "Steven", LastName = "King", BirthDate = new DateOnly(1947, 9, 21) },
            new Author() { Id = 3, FirstName = "Jon", LastName = "Doe", BirthDate = new DateOnly(1980, 1, 1) },
        };

        [HttpGet(Name = "GetAuthors")]
        public IActionResult Get(string firstName = "", string lastName = "", string bookTitle = "")
        {
            IEnumerable<Author> query = authors;

            
            if (firstName != "")
            {
                query = authors.Where(a => a.FirstName == firstName);
            }
            if (lastName != "")
            {
                query = authors.Where(a => a.LastName == lastName);
            }
            if(bookTitle != "")
            {
                query = authors.Where(a => a.Books.Any(b => b.Title == bookTitle));
            }
            if (query != null)
            {
                return Ok(query.ToList());
            }
            return NotFound();
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {
            Author author = authors.FirstOrDefault(a => a.Id == id);
            if(author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpPost(Name = "AddAuthor")]
        public IActionResult Post([FromBody] Author author)
        {
            
            if (author != null)
            {
                author.Id = authors.Max(a => a.Id) + 1;
                authors.Add(author);
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public IActionResult Delete(int id)
        {

            Author author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                authors.Remove(author);
                return Ok();
            }
            return NotFound();

        }

        [HttpPost("AddAuthorFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Author author)
        {
            Author newAuthor = new Author { Id = authors.Max(a => a.Id) + 1, FirstName = author.FirstName, LastName = author.LastName, BirthDate = author.BirthDate };
            if (newAuthor != null)
            {
                authors.Add(newAuthor);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetFromQuery")]
        public IActionResult GetFromQuery([FromQuery] int id)
        {

            Author author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpGet("GetFromBody")]
        public IActionResult GetFromBody([FromBody] int id)
        {
            Author author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpPost("{id}/AddBook")]
        public IActionResult AddBook(int id, [FromBody] Book book)
        {
            Author author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                if (author.Books == null)
                {
                    author.Books = new List<Book>();
                }
                book.Id = author.Books.Count > 0 ? author.Books.Max(b => b.Id) + 1 : 1;
                if (book != null)
                {
                    author.Books.Add(book);
                    return Ok();
                }
                else if (book == null)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }


    }
}
