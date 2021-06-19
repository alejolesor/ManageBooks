using Books_Api.dbAccess.dto;
using Books_Api.Irepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.services
{
    public class EditorialsService : IEditorialsService
    {
        private readonly IEditorialsRepository _editorialsRepository;
        public EditorialsService(IEditorialsRepository editorialsRepository)
        {
            _editorialsRepository = editorialsRepository;
        }
        public bool CreateEditorial(editorialsDto editorial)
        {
            return _editorialsRepository.CreateEditorial(editorial);
        }

        public IEnumerable<editorialsDto> GetEditorials()
        {
           return _editorialsRepository.GetEditorials();
        }
    }
}
