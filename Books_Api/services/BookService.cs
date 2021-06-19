using Books_Api.dbAccess.dto;
using Books_Api.repository.Irepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.services
{
    public class BookService : IBookService
    {

        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IEnumerable<booksDto> GetBooks()
        {
            return _booksRepository.GetBooks();

        }

        public bool CreateBook(booksDto book)
        {
            return _booksRepository.CreateBook(book);
        }

    }
}
