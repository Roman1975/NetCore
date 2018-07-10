using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoTest.Data;
using MongoTest.Model;

namespace MongoTest.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class TodosController : Controller
    {
        private readonly ITodoRepository _repo;

        public TodosController(ITodoRepository repo)
        {
            _repo = repo;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _repo.GetAll();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await _repo.Get(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]CreateModel value)
        {
            var todo = new Todo
            {
                Complete = false,
                Comments = new List<Comment>(),
                Description = value.Description,
                Priority = value.Priority,
                Title = value.Title,
                UserId = 1,
                Id = Guid.NewGuid()
            };
            await _repo.Add(todo);

            return Created($"http://localhost:5000/todos/{todo.Id}", value);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(string id)
        {
            await _repo.Complete(id);
            return NoContent();
        }

        [HttpPut("{id}/comment")]
        public async Task<IActionResult> Comment(string id, [FromBody]AddComment cmt)
        {
            var item = new Comment
            {
                Notes = cmt.Notes,
                UserId = cmt.UserId,
                CreatedOn = DateTime.Now,
                Id = Guid.NewGuid()
            };
            await _repo.AddComment(id, item);

            return Created($"http://localhost:5000/todos/{id}", item);
        }


        // PUT api/values/5
        // [HttpPut("{id}")]
        // public IActionResult Put(string id, [FromBody]Todo value)
        // {
        //     return BadRequest();
        // }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await _repo.Remove(id);
            return NoContent();
        }
    }
}