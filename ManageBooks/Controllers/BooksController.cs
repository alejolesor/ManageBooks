using ManageBooks.Models;
using ManageBooks.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBooks.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksApiClient _booksService;
        public BooksController(IBooksApiClient booksApiClient)
        {
            _booksService = booksApiClient;
        }
        public IActionResult Index()
        {
            List<Books> books = new List<Books>();
            var response = _booksService.GetBooksAsync();
            foreach (var item in response)
            {
                books.Add(new Books
                {
                   isbn = item.isbn,
                   editorials = item.editorials,
                   tittle = item.tittle,
                   synopsis = item.synopsis,
                   n_pages = item.n_pages
                });
            }
            return View(books);
        }

        public async Task<IActionResult> Create(Books books)
        {
            var result = await _booksService.CreateBooksAsync(books);
            return Ok(result);
        }
    }
}
