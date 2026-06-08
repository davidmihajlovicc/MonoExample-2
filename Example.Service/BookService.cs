using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository;
using Example.Service.Common;
using Example.Common;

namespace Example.Service
{
    public class BookService : IBookService
    {

        

        public IList<Book>? Get(BookFilter filter) {

            BookRepository bookRepository = new BookRepository();
            return bookRepository.Get(filter);

        }

        public bool Put(int id, Book book) {

            BookRepository bookRepository = new BookRepository();
            return bookRepository.Put(id, book);

        }

        public bool Delete(int id) {

            BookRepository bookRepository = new BookRepository();
            return bookRepository.Delete(id);

        }

        public Book? GetBook(int id) {

            BookRepository bookRepository = new BookRepository();
            return bookRepository.GetBook(id);
            
        }

        public bool PostBook(Book book) {

            BookRepository bookRepository = new BookRepository();
            return bookRepository.PostBook(book);
        
        }



    }
}
