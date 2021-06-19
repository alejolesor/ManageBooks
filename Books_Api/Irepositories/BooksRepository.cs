using Books_Api.dbAccess.dao;
using Books_Api.dbAccess.dto;
using Books_Api.repository.Irepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.Irepositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IDao _dao;

        public BooksRepository(IDao dao)
        {
            _dao = dao;
        }
        public IEnumerable<booksDto> GetBooks()
        {
           return _dao.Get();
        }
        public bool CreateBook(booksDto book)
        {
            return _dao.Create(book);
        }
    }
}
