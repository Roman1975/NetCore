using System;

namespace DoubleDbProvider.Domain.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

		public DateTimeOffset CreateDate { get; set; }

		public decimal Cost { get; set; }

        public bool Completed { get; set; }

		public short? KindId { get; set; }

		public virtual Kind Kind { get; set; }

    }


	
}