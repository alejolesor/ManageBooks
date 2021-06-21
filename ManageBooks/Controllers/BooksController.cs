using ManageBooks.Models;
using ManageBooks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var response = _booksService.GetBooksAsync();
            return View(response);
        }

        public IActionResult Create()
        {
            var listEditorials = _booksService.GetEditorialsBooks();
            List<SelectListItem> editorials = listEditorials.ConvertAll(e =>
            {
                return new SelectListItem()
                {
                    Text = e.name.ToString(),
                    Value = e.id.ToString(),
                    Selected = false
                };
            });

            ViewBag.editorials = editorials;

            return View();
        }

        public async Task<IActionResult> CreateBooks(Books books)
        {
            string editorial = Request.Form["editorial"].ToString();
            books.editorials = int.Parse(editorial);
            var result = await _booksService.CreateBooksAsync(books);
            return Ok(result);
        }
    }
}
