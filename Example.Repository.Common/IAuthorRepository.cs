using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Repository.Common
{
    public interface IAuthorRepository
    {

        public Task<IList<Author>?> GetAsync(AuthorFilter filter);

        public Task<bool> PutAsync(int id, Author author);


        public Task<bool> DeleteAsync(int id);

        public Task<bool> AddBookToAuthorAsync(BookAuthor bookAuthor);

        public Task<Author?> GetAuthorAsync(int id);

        public Task<bool> PostAuthorAsync(Author author);


    }
}
