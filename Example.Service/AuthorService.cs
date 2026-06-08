using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository;
using Example.Service.Common;

namespace Example.Service
{
    public class AuthorService : IAuthorService
    {

        public async Task<IList<Author>?> GetAsync(AuthorFilter filter) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.GetAsync(filter);
        
        }

        public async Task<Author?> GetAuthorAsync(int id) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.GetAuthorAsync(id);
        
        }

        public async Task<bool> PostAuthorAsync(Author author) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.PostAuthorAsync(author);

        }

        public async Task<bool> PutAsync(int id, Author author) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.PutAsync(id, author);
        
        }

        public async Task<bool> DeleteAsync(int id) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.DeleteAsync(id);
        
        }

        public async Task<bool> AddBookToAuthorAsync(BookAuthor bookAuthor) {

            AuthorRepository authorRepository = new AuthorRepository();
            return await authorRepository.AddBookToAuthorAsync(bookAuthor);

        }

    }
}
