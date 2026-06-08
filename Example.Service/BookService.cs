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


        public async Task<IList<Book>?> GetAsync(BookFilter filter) {

            BookRepository bookRepository = new BookRepository();
            return await bookRepository.GetAsync(filter);

        }

        public async Task<bool> PutAsync(int id, Book book) {

            BookRepository bookRepository = new BookRepository();
            return await bookRepository.PutAsync(id, book);

        }

        public async Task<bool> DeleteAsync(int id) {

            BookRepository bookRepository = new BookRepository();
            return await bookRepository.DeleteAsync(id);

        }

        public async Task<Book?> GetBookAsync(int id) {

            BookRepository bookRepository = new BookRepository();
            return await bookRepository.GetBookAsync(id);
            
        }

        public async Task<bool> PostBookAsync(Book book) {

            BookRepository bookRepository = new BookRepository();
            return await bookRepository.PostBookAsync(book);
        
        }



    }
}
