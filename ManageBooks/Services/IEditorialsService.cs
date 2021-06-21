using ManageBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBooks.Services
{
    public interface IEditorialsService
    {
        List<Editorials> GetEditorials();

        Task<bool> CreateEditorials(Editorials editorials);
    }
}
