using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository.Common;
using Example.Service.Common;

namespace Example.Service
{
    public class AuthorService : IAuthorService
    {

        private IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository) {
            
            this.authorRepository = authorRepository;
        
        }

        public async Task<IList<Author>?> GetAsync(AuthorFilter filter) {

            return await authorRepository.GetAsync(filter);
        
        }

        public async Task<Author?> GetAuthorAsync(int id) {

            return await authorRepository.GetAuthorAsync(id);
        
        }

        public async Task<bool> PostAuthorAsync(Author author) {

            return await authorRepository.PostAuthorAsync(author);

        }

        public async Task<bool> PutAsync(int id, Author author) {

            return await authorRepository.PutAsync(id, author);
        
        }

        public async Task<bool> DeleteAsync(int id) {

            return await authorRepository.DeleteAsync(id);
        
        }

        public async Task<bool> AddBookToAuthorAsync(BookAuthor bookAuthor) {

            return await authorRepository.AddBookToAuthorAsync(bookAuthor);

        }

    }
}
