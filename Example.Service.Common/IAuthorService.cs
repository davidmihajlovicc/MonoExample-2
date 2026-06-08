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

        public IList<Author>? Get(AuthorFilter filter);

        public Author? GetAuthor(int id);

        public bool PostAuthor(Author author);

        public bool Put(int id, Author author);

        public bool Delete(int id);

        public bool AddBookToAuthor(BookAuthor bookAuthor);


    }
}
