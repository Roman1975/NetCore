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
    public class Comment : DomainModel
    {
        public int UserId { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string Notes { get; set; }
    }
}
