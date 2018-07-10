using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MongoTest.Model
{
    public class Todo : DomainModel
    {
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public DateTime? CompletedOn { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

    }
}
