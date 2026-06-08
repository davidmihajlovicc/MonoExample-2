using Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Common;

namespace Example.Service.Common
{
    public interface IBookService
    {

        public IList<Book>? Get(BookFilter filter);

        public bool Put(int id, Book book);

        public bool Delete(int id);

        public Book? GetBook(int id);

        public bool PostBook(Book book);

    }
}
