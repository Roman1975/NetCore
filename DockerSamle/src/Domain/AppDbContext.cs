using Microsoft.EntityFrameworkCore;

namespace GaugeCommand.Domain
{
 public class AppDbContext: DbContext
    {
        public AppDbContext
        (DbContextOptions<AppDbContext> options)  
            : base(options)  
        { }

        public DbSet<Todo> Todos { get; set; }
    }
}