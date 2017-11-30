using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreapiwithpostgresql.Domain;
using coreapiwithpostgresql.Filters;
using coreapiwithpostgresql.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace coreapiwithpostgresql.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoDbContext _context;
        public TodosController(TodoDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Todos.ToListAsync();
            return Ok(items);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> Get(int id)
        {

            var todo = await GetItem(id);
            if (todo == null)
            {
                return NotFound();
            }
            return new ObjectResult(todo);
        }

        private async Task<TodoItem> GetItem(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TodoItem item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            

            await _context.Todos.AddAsync(item);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var dbItem = await GetItem(id);
            if (dbItem == null)
            {
                return NotFound();
            }
            else{
                dbItem.DateFinish = item.DateFinish;
                dbItem.DateStart = item.DateStart;
                dbItem.IsCompleted = item.IsCompleted;
                dbItem.Title = item.Title;
            }

            _context.Todos.Update(dbItem);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await GetItem(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
