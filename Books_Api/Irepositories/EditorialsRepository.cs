using Books_Api.dbAccess.daoEditorials;
using Books_Api.dbAccess.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.Irepositories
{
    public class EditorialsRepository : IEditorialsRepository
    {
        private readonly IDao _dao;

        public EditorialsRepository(IDao dao)
        {
            _dao = dao;
        }
        public bool CreateEditorial(editorialsDto editorial)
        {
            return _dao.Create(editorial);
        }

        public IEnumerable<editorialsDto> GetEditorials()
        {
            return _dao.Get();
        }
    }
}
