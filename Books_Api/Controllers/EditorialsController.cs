using Books_Api.dbAccess.dto;
using Books_Api.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private readonly IEditorialsService _editorialsService;
        public EditorialsController(IEditorialsService editorialsService)
        {
            _editorialsService = editorialsService;
        }

        [HttpGet]
        public IEnumerable<editorialsDto> GetEditorial()
        {
            return _editorialsService.GetEditorials();
        }
        [HttpPost]
        public bool CreateEditorial(editorialsDto editorials)
        {
            return _editorialsService.CreateEditorial(editorials);
        }
    }
}
