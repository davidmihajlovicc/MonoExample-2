using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;

namespace Example.Repository.Common
{
    public interface IBookRepository
    {

        public Task<IList<Book>?> GetAsync(BookFilter filter);

        public Task<bool> PutAsync(int id, Book book);

        public Task<bool> Delete(int id);

        public Task<Book?> GetBook(int id);

        public Task<bool> PostBook(Book book);


    }
}
