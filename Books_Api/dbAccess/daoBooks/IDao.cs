using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.dao
{
    public interface IDao
    {
        IEnumerable<booksDto> Get();
        bool Create(booksDto book);
    }
}
