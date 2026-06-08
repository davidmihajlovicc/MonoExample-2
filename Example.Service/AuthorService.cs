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

        public IList<Author>? Get(AuthorFilter filter) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.Get(filter);
        
        }

        public Author? GetAuthor(int id) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.GetAuthor(id);
        
        }

        public bool PostAuthor(Author author) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.PostAuthor(author);

        }

        public bool Put(int id, Author author) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.Put(id, author);
        
        }

        public bool Delete(int id) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.Delete(id);
        
        }

        public bool AddBookToAuthor(BookAuthor bookAuthor) {

            AuthorRepository authorRepository = new AuthorRepository();
            return authorRepository.AddBookToAuthor(bookAuthor);

        }

    }
}
