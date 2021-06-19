using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.dbAccess.daoEditorials
{
    public interface IDao
    {
        IEnumerable<editorialsDto> Get();
        bool Create(editorialsDto editorial);
    }
}
