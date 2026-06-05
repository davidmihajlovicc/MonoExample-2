using Microsoft.AspNetCore.Mvc;
using System.Text;



namespace Example.WebApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuthorsController: ControllerBase
    {


        string connectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=postgre;";

        IList<Author> authors = new List<Author>()
        {
            new Author() { Id = 1, FirstName = "JK", LastName = "Rowling", BirthDate = new DateOnly(1965, 7, 31) },
            new Author() { Id = 2, FirstName = "Steven", LastName = "King", BirthDate = new DateOnly(1947, 9, 21) },
            new Author() { Id = 3, FirstName = "Jon", LastName = "Doe", BirthDate = new DateOnly(1980, 1, 1) },
        };

        [HttpGet(Name = "GetAuthors")]
        public IActionResult Get(string firstName = "", string lastName = "", string bookTitle = "")
        {

            var authors = new List<Author>();
            try { 
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                StringBuilder sqlCommand = new StringBuilder("SELECT \"Id\", \"FirstName\", \"LastName\", \"BirthDate\" FROM \"Author\" WHERE 1=1");

                using var command = new Npgsql.NpgsqlCommand();
                if (firstName != "")
                {
                    sqlCommand.Append(" AND \"FirstName\" = @firstName");
                    command.Parameters.AddWithValue("firstName", firstName);
                }
                if (lastName != "")
                {
                    sqlCommand.Append(" AND \"LastName\" = @lastName");
                    command.Parameters.AddWithValue("lastName", lastName);
                }
                if (bookTitle != "")
                {
                    sqlCommand.Append(" AND \"BookTitle\" = @bookTitle");
                    command.Parameters.AddWithValue("bookTitle", bookTitle);
                }

                
              
                command.CommandText = sqlCommand.ToString();

                command.Connection = connection;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Author author = new Author();
                    author.Id = reader.GetFieldValue<int>(0);
                    author.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetFieldValue<string>(1);
                    author.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetFieldValue<string>(2);
                    author.BirthDate = reader.IsDBNull(3) ? new DateOnly() : reader.GetFieldValue<DateOnly>(3);
                    authors.Add(author);
                }

                connection.Close();
                if(authors!= null && authors.Any())
                {
                    return Ok(authors);
                }
                return NotFound();

            } catch (Exception ex) { 
                return BadRequest(ex.Message); 
            }

        }


        [HttpGet("{id}", Name = "GetAuthor")]
        public IActionResult Get(int id)
        {

            try {

                Author author = GetAuthor(id);
                if (author != null) {
                    return Ok(author);
                }
                return NotFound();
            
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
           
        }



        [HttpPost(Name = "AddAuthor")]
        public IActionResult Post([FromBody] Author author)
        {
            

            try {
                
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("INSERT INTO \"Author\" (\"FirstName\", \"LastName\", \"BirthDate\") " +
                    "VALUES (@firstName, @lastName, @birthDate)", connection);

                
                command.Parameters.AddWithValue("firstName", author.FirstName);
                command.Parameters.AddWithValue("lastName", author.LastName);
                command.Parameters.AddWithValue("birthDate", author.BirthDate);

               /* nema smisla
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                using var commandSelectId = new Npgsql.NpgsqlCommand("SELECT \"Id\" FROM \"Author\" " +
                    "WHERE \"FirstName\" = @firstName AND \"LastName\" = @lastName AND  \"BirthDate\" = @birthDate", connection);
                commandSelectId.Parameters.AddWithValue("firstName", author.FirstName);
                commandSelectId.Parameters.AddWithValue("lastName", author.LastName);
                commandSelectId.Parameters.AddWithValue("birthDate", author.BirthDate);
                var reader = commandSelectId.ExecuteReader();

                reader.Read();
                author.Id = reader.GetFieldValue<int>(0);
                connection.Close();
                


                using var commandSelectBookAuthor = new Npgsql.NpgsqlCommand("SELECT * FROM \"BookAuthor\" WHERE \"AuthorId\" = @id", connection);
                commandSelectBookAuthor.Parameters.AddWithValue("id", author.Id);
                connection.Open();

                reader = commandSelectBookAuthor.ExecuteReader();

                if (!reader.HasRows) {
                    command.CommandText = "INSERT INTO \"BookAuthor\" (\"AuthorId\") VALUES (@id)";
                    command.Parameters.AddWithValue("id", author.Id);
                    connection.Close();
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close() ;
                    
                }
               */
                
                return Ok();


            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}", Name = "UpdateAuthor")]
        public IActionResult Put(int id, Author author) {
            
            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("UPDATE \"Author\" " +
                    "SET \"FirstName\" = @firstName, \"LastName\" = @lastName, \"BirthDate\" = @birthDate " +
                    "WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", author.Id);
                command.Parameters.AddWithValue("firstName", author.FirstName);
                command.Parameters.AddWithValue("lastName", author.LastName);
                command.Parameters.AddWithValue("birthDate", author.BirthDate);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return Ok("Uspjesno");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpDelete("{id}", Name = "DeleteAuthor")]
        public IActionResult Delete(int id)
        {


            try {
                
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("DELETE FROM \"Author\" WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();
                int numberOfRows = command.ExecuteNonQuery();
                if (numberOfRows == 0)
                {
                    return NotFound();
                }
                connection.Close();
                return Ok();

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message); 
            }

          

        }

        [HttpPost("AddAuthorFromQuery")]
        public IActionResult PostFromQuery([FromQuery] Author author)
        {


            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("INSERT INTO \"Author\" (\"FirstName\", \"LastName\", \"BirthDate\") " +
                    "VALUES (@firstName, @lastName, @birthDate)", connection);


                command.Parameters.AddWithValue("firstName", author.FirstName);
                command.Parameters.AddWithValue("lastName", author.LastName);
                command.Parameters.AddWithValue("birthDate", author.BirthDate);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return Ok();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("GetFromQuery")]
        public IActionResult GetFromQuery([FromQuery] int id)
        {

            try
            {

                Author author = GetAuthor(id);
                if (author != null)
                {
                    return Ok(author);
                }
                return NotFound();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetFromBody")]
        public IActionResult GetFromBody([FromBody] int id)
        {
            try
            {

                Author author = GetAuthor(id);
                if (author != null)
                {
                    return Ok(author);
                }
                return NotFound();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private Author GetAuthor(int id)
        {


            Author author = new Author();
            using var connection = new Npgsql.NpgsqlConnection(connectionString);
            using var command = new Npgsql.NpgsqlCommand("SELECT \"Id\", \"FirstName\", \"LastName\", \"BirthDate\" " +
                "FROM \"Author\" WHERE \"Id\" = @id", connection);

            command.Parameters.AddWithValue("id", id);
            connection.Open();
            var reader = command.ExecuteReader();
            reader.Read();
            author.Id = reader.GetFieldValue<int>(0);
            author.FirstName = reader.IsDBNull(1) ? string.Empty : reader.GetFieldValue<string>(1);
            author.LastName = reader.IsDBNull(2) ? string.Empty : reader.GetFieldValue<string>(2);
            author.BirthDate = reader.IsDBNull(3) ? new DateOnly() : reader.GetFieldValue<DateOnly>(3);

            connection.Close();

            if (author != null)
            {
                return author;
            }
            return null;



        }

    }
}
