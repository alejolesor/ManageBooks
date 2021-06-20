using ManageBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBooks.Services
{
    public interface IBooksApiClient
    {
        List<Books> GetBooksAsync();
        Task<bool> CreateBooksAsync(Books book);
    }
}
