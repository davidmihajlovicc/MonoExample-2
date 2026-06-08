using System.Reflection.Metadata.Ecma335;
using System.Text;
using Example.Model;
using Example.Repository.Common;
using Example.Common;

namespace Example.Repository
{
    public class BookRepository : IBookRepository
    {

        
        string connectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=postgre;";
        public async Task<IList<Book>?> GetAsync(BookFilter filter)
        {

            var books = new List<Book>();
            try
            {
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                StringBuilder sqlCommand = new StringBuilder("SELECT b.\"Title\", b.\"ReleaseDate\", b.\"PageCount\", b.\"ISBN\", a.\"FirstName\", a.\"LastName\" " +
                    "FROM \"Book\" b  " +
                    "LEFT JOIN  \"BookAuthor\" ab on b.\"Id\" = ab.\"BookId\"" +
                    "LEFT JOIN \"Author\" a on a.\"Id\" = ab.\"AuthorId\"" +
                    "WHERE 1=1");

                using var command = new Npgsql.NpgsqlCommand();

                if (filter.Title != "")
                {
                    sqlCommand.Append(" AND b.\"Title\" = @Id");
                    command.Parameters.AddWithValue("title", filter.Title);
                }
                if (filter.ISBN != "")
                {
                    sqlCommand.Append(" AND b.\"ISBN\" = @ISBN");
                    command.Parameters.AddWithValue("ISBN", filter.ISBN);
                }
                if (filter.AuthorName != "")
                {
                    sqlCommand.Append(" AND a.\"FirstName\" = @authorName");
                    command.Parameters.AddWithValue("authorName", filter.AuthorName);
                }
                if (filter.AuthorLastName != "")
                {
                    sqlCommand.Append(" AND a.\"LastName\" = @authorName");
                    command.Parameters.AddWithValue("lastName", filter.AuthorLastName);
                }

                command.CommandText = sqlCommand.ToString();
                command.Connection = connection;


                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.Title = reader.IsDBNull(0) ? string.Empty : reader.GetFieldValue<string>(0);
                    book.ReleaseDate = reader.IsDBNull(1) ? new DateOnly() : reader.GetFieldValue<DateOnly>(1);
                    book.PageCount = reader.IsDBNull(2) ? 0 : reader.GetFieldValue<int>(2);
                    book.ISBN = reader.IsDBNull(3) ? string.Empty : reader.GetFieldValue<string>(3);
                    books.Add(book);
                }

                connection.Close();
                if (books != null && books.Any())
                {
                    return books;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }




        public async Task<bool> PutAsync(int id, Book book)
        {


            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("UPDATE \"Book\" " +
                    "SET \"Title\" = @title, \"ReleaseDate\" = @releaseDate, \"PageCount\" = @pageCount, \"ISBN\" = @ISBN" +
                    " WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("title", book.Title);
                command.Parameters.AddWithValue("releaseDate", book.ReleaseDate);
                command.Parameters.AddWithValue("pageCount", book.PageCount);
                command.Parameters.AddWithValue("ISBN", book.ISBN);

                connection.Open();
                int rowsAffected  = await command.ExecuteNonQueryAsync();
                connection.Close();

                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> Delete(int id)
        {

            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("DELETE FROM \"Book\" WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();
                int numberOfRows = command.ExecuteNonQuery();
                connection.Close();
                if (numberOfRows == 0)
                {
                    return false;
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }



        public async Task<Book?> GetBook(int id)
        {

            try
            {

                Book book = new Book();
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("SELECT *" +
                    "FROM \"Book\" WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                reader.Read();
                book.Id = reader.GetFieldValue<int>(0);
                book.Title = reader.IsDBNull(1) ? string.Empty : reader.GetFieldValue<string>(1);
                book.PageCount = reader.GetFieldValue<int>(3);
                book.ReleaseDate = reader.IsDBNull(2) ? new DateOnly() : reader.GetFieldValue<DateOnly>(2);
                book.ISBN = reader.IsDBNull(4) ? string.Empty : reader.GetFieldValue<string>(4);

                connection.Close();

                if (book != null)
                {
                    return book;
                }
                return null;
            }
            catch (Exception) { return null; }


        }

        public async Task<bool> PostBook(Book book)
        {
            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("INSERT INTO \"Book\" (\"Title\", \"ReleaseDate\", \"PageCount\", \"ISBN\") " +
                    "VALUES (@title, @releaseDate, @pageCount, @ISBN)", connection);

                command.Parameters.AddWithValue("title", book.Title);
                command.Parameters.AddWithValue("releaseDate", book.ReleaseDate);
                command.Parameters.AddWithValue("pageCount", book.PageCount);
                command.Parameters.AddWithValue("ISBN", book.ISBN);

                connection.Open();
                int numberOfRowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (numberOfRowsAffected > 0) {
                    return true;
                }
                return false;
            }
            catch (Exception) { return false;  }
        }

    }
}
