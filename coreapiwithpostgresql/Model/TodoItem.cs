using System;
using System.ComponentModel.DataAnnotations;

namespace coreapiwithpostgresql.Model
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        
        [Required(ErrorMessage = "Todo title is required")]
        public string Title { get; set; }
        
        
        public DateTime? DateStart { get; set; }
        
       
        public DateTime? DateFinish { get; set; }
    }
}
