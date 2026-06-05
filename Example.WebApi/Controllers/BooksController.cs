using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        string connectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=postgre;";


        [HttpGet(Name = "GetBooks")]
        public IActionResult Get([FromQuery] string ISBN = "", [FromQuery] string title = "", [FromQuery] string authorName = "", [FromQuery] string authorLastName = "")
        {

            var books = new List<Book>();
            try
            {
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                StringBuilder sqlCommand = new StringBuilder("SELECT b.\"Title\", b.\"ReleaseDate\", b.\"PageCount\", b.\"ISBN\", a.\"FirstName\", a.\"LastName\" " +
                    "FROM \"Book\" b  " +
                    "LEFT JOIN  \"BookAuthor\" ab on b.\"Id\" = ab.\"BookId\"" +
                    "LEFT JOIN \"Author\" a on a.\"Id\" = ab.\"AuthorId\"" +
                    "WHERE 1=1") ;

                using var command = new Npgsql.NpgsqlCommand();

                if (title != "")
                {
                    sqlCommand.Append(" AND b.\"Title\" = @Id");
                    command.Parameters.AddWithValue("title", title);
                }
                if (ISBN != "")
                {
                    sqlCommand.Append(" AND b.\"ISBN\" = @ISBN");
                    command.Parameters.AddWithValue("ISBN", ISBN);
                }
                if (authorName != "")
                {
                    sqlCommand.Append(" AND a.\"FirstName\" = @authorName");
                    command.Parameters.AddWithValue("authorName", authorName);
                }
                if(authorLastName != "")
                {
                    sqlCommand.Append(" AND a.\"LastName\" = @authorName");
                    command.Parameters.AddWithValue("lastName", authorLastName);
                }

                command.CommandText = sqlCommand.ToString();
                command.Connection = connection;
                

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.Title = reader.IsDBNull(0) ? string.Empty : reader.GetFieldValue<string>(0);
                    book.ReleaseDate = reader.IsDBNull (1) ? new DateOnly() : reader.GetFieldValue<DateOnly>(1);
                    book.PageCount = reader.IsDBNull(2) ? 0 : reader.GetFieldValue<int>(2);
                    book.ISBN = reader.IsDBNull(3) ? string.Empty : reader.GetFieldValue<string>(3);
                    books.Add(book);
                }

                connection.Close();
                if (books != null && books.Any())
                {
                    return Ok(books);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
