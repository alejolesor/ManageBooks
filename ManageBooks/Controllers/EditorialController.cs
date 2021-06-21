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
    public class EditorialController : Controller
    {
        private readonly IEditorialsService _editorialsService;
        public EditorialController(IEditorialsService editorialsService)
        {
            _editorialsService = editorialsService;
        }
        public IActionResult Index()
        {
            var response = _editorialsService.GetEditorials();
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateEditorial(Editorials editorials)
        {
            var result = await _editorialsService.CreateEditorials(editorials);
            return Ok(result);
        }

    }
}
