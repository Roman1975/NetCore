using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayeredApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var items = _unitOfWork.TodoRepository.GetAll();
            return Ok(items);
        }
    }
}
