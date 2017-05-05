using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayeredApp.Application;
using LayeredApp.Application.Interface;
using LayeredApp.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly ITodoLogic _todoLogic;

        public TodosController(IUnitOfWork unitOfWork)
        {
            _todoLogic = new TodoLogic(unitOfWork);

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var items = _todoLogic.Get();
            return Ok(items);
        }
    }
}
