using System.ComponentModel.DataAnnotations;

namespace GaugeCommand.Domain
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}