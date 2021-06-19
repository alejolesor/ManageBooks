using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.services
{
    public interface IEditorialsService
    {
        IEnumerable<editorialsDto> GetEditorials();
        bool CreateEditorial(editorialsDto editorial);
    }
}
