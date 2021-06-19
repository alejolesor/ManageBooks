using Books_Api.dbAccess.dto;
using Books_Api.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _booksService;
        public BooksController(IBookService bookService)
        {
            _booksService = bookService;
        }

        [HttpGet]
        public IEnumerable<booksDto> Get()
        {
            return _booksService.GetBooks();
        }
        [HttpPost]
        public bool CreateBooks(booksDto books)
        {
            return _booksService.CreateBook(books);
        }

    }
}
