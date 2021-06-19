using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.repository.Irepositories
{
    public interface IBooksRepository
    {
        IEnumerable<booksDto> GetBooks();
        bool CreateBook(booksDto book);
    }
}
