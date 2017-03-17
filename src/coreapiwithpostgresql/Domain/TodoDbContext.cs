using coreapiwithpostgresql.Model;
using Microsoft.EntityFrameworkCore;  
  
namespace coreapiwithpostgresql.Domain  
{  
    public class TodoDbContext : DbContext    
    {   
        public TodoDbContext(DbContextOptions<TodoDbContext> options)  
            : base(options)  
        { }  
  
        public DbSet<TodoItem> Todos { get; set; }  
    }  
}   