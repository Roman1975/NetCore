using System;

namespace LayeredApp.Model
{
    public class TodoModel
    {
        public int Id { get; set; }

        //[Display(Name = "Назва")]
        //[StringLength(50, MinimumLength = 5, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
    }
}
