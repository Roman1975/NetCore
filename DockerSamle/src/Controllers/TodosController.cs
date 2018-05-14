using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaugeCommand.Commands;
using GaugeCommand.Domain;
using GaugeCommand.Models;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace GaugeCommand.Controllers
{
    /// <summary>
    /// this controller needs only for tests
    /// </summary>
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        AppDbContext _context;
        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = _context.Todos.FirstOrDefault(x => x.Id == id);

            if (todo != null)
                return Ok(todo);
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Todos.AsEnumerable());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            if(ModelState.IsValid)
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
            }
            return Created($"/api/todos/{todo.Id}", todo);
        }
    }
}
