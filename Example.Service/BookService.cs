using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Model;
using Example.Repository;
using Example.Repository.Common;
using Example.Service.Common;
using Example.Common;
using Example.Model.Domain;

namespace Example.Service
{
    public class BookService : IBookService
    {

        private IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository) {
        
            this.bookRepository = bookRepository;

        }

        public async Task<IList<Book>?> GetAsync(BookFilter filter) {

            return await bookRepository.GetAsync(filter);

        }

        public async Task<bool> PutAsync(int id, Book book) {

            return await bookRepository.PutAsync(id, book);

        }

        public async Task<bool> DeleteAsync(int id) {

            return await bookRepository.DeleteAsync(id);

        }

        public async Task<Book?> GetBookAsync(int id) {

            return await bookRepository.GetBookAsync(id);
            
        }

        public async Task<bool> PostBookAsync(Book book) {

            return await bookRepository.PostBookAsync(book);
        
        }



    }
}
