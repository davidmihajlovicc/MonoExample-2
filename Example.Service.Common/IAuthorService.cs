using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Common;

namespace Example.Service.Common
{
    public interface IAuthorService
    {

        public Task<IList<Author>?> GetAsync(AuthorFilter filter);

        public Task<Author?> GetAuthorAsync(int id);

        public Task<bool> PostAuthorAsync(Author author);

        public Task<bool> PutAsync(int id, Author author);

        public Task<bool> DeleteAsync(int id);

        public Task<bool> AddBookToAuthorAsync(BookAuthor bookAuthor);


    }
}
