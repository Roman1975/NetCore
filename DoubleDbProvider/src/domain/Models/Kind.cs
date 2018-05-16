using System.Collections.Generic;

namespace DoubleDbProvider.Domain.Models
{
    public class Kind
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Todo> Todos { get; set; }

    }
}
