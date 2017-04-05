using System;
using System.ComponentModel.DataAnnotations;

namespace AutomapperTest.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }

}