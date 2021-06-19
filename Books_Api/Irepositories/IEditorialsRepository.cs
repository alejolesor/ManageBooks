using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.Irepositories
{
    public interface IEditorialsRepository
    {
        IEnumerable<editorialsDto> GetEditorials();
        bool CreateEditorial(editorialsDto editorial);
    }
}
