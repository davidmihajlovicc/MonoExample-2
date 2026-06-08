using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository.Common;

namespace Example.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        string connectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=postgre;";


        
        public async Task<IList<Author>?> GetAsync(AuthorFilter filter)
        {

            var authors = new List<Author>();
            try
            {
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                StringBuilder sqlCommand = new StringBuilder("SELECT \"Id\", \"FirstName\", \"LastName\", \"BirthDate\" FROM \"Author\" WHERE 1=1");

                using var command = new Npgsql.NpgsqlCommand();
                if (filter.FirstName != "")
                {
                    sqlCommand.Append(" AND \"FirstName\" = @firstName");
                    command.Parameters.AddWithValue("firstName", filter.FirstName);
                }
                if (filter.LastName != "")
                {
                    sqlCommand.Append(" AND \"LastName\" = @lastName");
                    command.Parameters.AddWithValue("lastName", filter.LastName);
                }
                if (filter.BookTitle != "")
                {
                    sqlCommand.Append(" AND \"BookTitle\" = @bookTitle");
                    command.Parameters.AddWithValue("bookTitle", filter.BookTitle);
                }



                command.CommandText = sqlCommand.ToString();

                command.Connection = connection;
                connection.Open();
                var reader = await command.ExecuteReaderAsync();
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
                if (authors != null && authors.Any())
                {
                    return authors;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }

        }
        public async Task<bool> PutAsync(int id, Author author)
        {

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
                int rowsAffected = await command.ExecuteNonQueryAsync();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else { return false; }


            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public async Task<bool> DeleteAsync(int id)
        {


            try
            {

                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("DELETE FROM \"Author\" WHERE \"Id\" = @id", connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();
                int numberOfRows = await command.ExecuteNonQueryAsync();
                if (numberOfRows == 0)
                {
                    return false;
                }
                connection.Close();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }



        }



        public async Task<bool> AddBookToAuthorAsync(BookAuthor bookAuthor)
        {

            try
            {
                using var connection = new Npgsql.NpgsqlConnection(connectionString);
                using var command = new Npgsql.NpgsqlCommand("SELECT * from \"BookAuthor\" WHERE \"AuthorId\" = @authorId AND \"BookId\" = @bookId", connection);


                command.Parameters.AddWithValue("authorId", bookAuthor.AuthorId);
                command.Parameters.AddWithValue("bookId", bookAuthor.BookId);


                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    connection.Close();
                    return false;
                }
                else
                {
                    connection.Close();
                    using var commandInsert = new Npgsql.NpgsqlCommand("INSERT INTO \"BookAuthor\" (\"AuthorId\", \"BookId\") VALUES (@authorId, @bookId)", connection);


                    commandInsert.Parameters.AddWithValue("authorId", bookAuthor.AuthorId);
                    commandInsert.Parameters.AddWithValue("bookId", bookAuthor.BookId);


                    connection.Open();
                    int numberOfRowsAffected = commandInsert.ExecuteNonQuery();
                    connection.Close();

                    if (numberOfRowsAffected > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {

                return false;

            }


        }


        public async Task<Author?> GetAuthorAsync(int id)
        {


            Author author = new Author();
            using var connection = new Npgsql.NpgsqlConnection(connectionString);
            using var command = new Npgsql.NpgsqlCommand("SELECT \"Id\", \"FirstName\", \"LastName\", \"BirthDate\" " +
                "FROM \"Author\" WHERE \"Id\" = @id", connection);

            command.Parameters.AddWithValue("id", id);
            connection.Open();
            var reader = await command.ExecuteReaderAsync();
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

        public async Task<bool> PostAuthorAsync(Author author)
        {

            using var connection = new Npgsql.NpgsqlConnection(connectionString);
            using var command = new Npgsql.NpgsqlCommand("INSERT INTO \"Author\" (\"FirstName\", \"LastName\", \"BirthDate\") " +
                "VALUES (@firstName, @lastName, @birthDate)", connection);


            command.Parameters.AddWithValue("firstName", author.FirstName);
            command.Parameters.AddWithValue("lastName", author.LastName);
            command.Parameters.AddWithValue("birthDate", author.BirthDate);


            connection.Open();
            int numberOfRowsAffected = await command.ExecuteNonQueryAsync();
            connection.Close();

            if (numberOfRowsAffected > 0) {
                return true;
            }
            return false;
        }
    }
}
