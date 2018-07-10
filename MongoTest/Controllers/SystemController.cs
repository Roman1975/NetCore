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
    public class SystemController : Controller
    {
        private readonly ITodoRepository _repo;

        public SystemController(ITodoRepository repo)
        {
            _repo = repo;
        }
        

        [HttpGet("{value}")]
        public string Get(string value)
        {
            if (value == "init")
            {
                var emptyComments = new List<Comment>();
                _repo.RemoveAll();
                _repo.Add(new Todo()
                {
                    Title = "Test note 1",
                    CreatedOn = DateTime.Now,
                    Description = "some description 1",
                    Priority = 1,
                    Complete = false,
                    UserId = 1,
                    Comments = emptyComments,
                    Id = Guid.NewGuid()
                });

                _repo.Add(new Todo()
                {
                    Title = "Test note 2",
                    CreatedOn = DateTime.Now,
                    Description = "some description 2",
                    Priority = 1,
                    Complete = false,
                    UserId = 1,
                    Comments = emptyComments,
                    Id = Guid.NewGuid()
                });

                _repo.Add(new Todo()
                {
                    Title = "Test note 3",
                    CreatedOn = DateTime.Now,
                    Description = "some description 3",
                    Priority = 1,
                    Complete = false,
                    UserId = 1,
                    Comments = emptyComments,
                    Id = Guid.NewGuid()
                });

                return "Done";
            }
            return "Unknown";
        }
    }
}