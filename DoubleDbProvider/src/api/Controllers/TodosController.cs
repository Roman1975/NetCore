using System;
using System.Linq;
using DoubleDbProvider.Domain;
using DoubleDbProvider.Domain.Models;
using DoubleDbProvider.DomainPG;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleDbProvider.API.Controllers
{
    /// <summary>
    /// this controller needs only for tests
    /// </summary>
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        SqlDbContext _context;
        public TodosController(IServiceProvider services)
        {
            var sql = services.GetService<SqlDbContext>();
            var pgsql = services.GetService<PostgresDbContext>();

            _context = pgsql ?? sql;
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
