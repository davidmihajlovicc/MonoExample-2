using Microsoft.AspNetCore.Mvc;

namespace Example.WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthorsController
    {


        IList<Author> authors = new List<Author>()
        {
            new Author() { Id = 1, FirstName = "JK", LastName = "Rowling", BirthDate = new DateOnly(1965, 7, 31) },
            new Author() { Id = 2, FirstName = "Steven", LastName = "King", BirthDate = new DateOnly(1947, 9, 21) },
            new Author() { Id = 3, FirstName = "Jon", LastName = "Doe", BirthDate = new DateOnly(1980, 1, 1) },
        };

        [HttpGet(Name = "GetAuthors")]
        public IList<Author> Get()
        {
            return authors.ToArray();
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public Author Get(int id)
        {
            Author author = authors.FirstOrDefault(a => a.Id == id);
            if(author != null)
            {
                return author;
            }
            return null;
        }

        [HttpPost(Name = "AddAuthor")]
        public bool Post([FromBody] Author author)
        {
            author.Id = authors.Max(a => a.Id) + 1;
            if (author != null)
            {
                authors.Add(author);
                return true;
            }
            return false;
        }

        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public bool Delete(int id)
        {

            Author author = authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                authors.Remove(author);
                return true;
            }
            return false;

        }

        [HttpPost("AddAuthorFromQuery")]
        public bool PostFromQuery([FromQuery] Author author)
        {
            Author newAuthor = new Author { Id = authors.Max(a => a.Id) + 1, FirstName = author.FirstName, LastName = author.LastName, BirthDate = author.BirthDate };
            if (newAuthor != null)
            {
                authors.Add(newAuthor);
                return true;
            }
            return false;
        }

        [HttpGet("GetFromQuery")]
        public Author GetFromQuery([FromQuery] int id)
        {

            return authors.FirstOrDefault(a => a.Id == id);

        }

        [HttpPost("{id}/AddBook")]
        public bool AddBook(int id, [FromBody] Book book)
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
                    return true;
                }
            }
            return false;
        }


    }
}
