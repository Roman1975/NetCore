using Microsoft.EntityFrameworkCore;  
  
namespace LayeredApp.Domain
{  
    public class MyDbContext : DbContext    
    {   
        public MyDbContext(DbContextOptions<MyDbContext> options)  
            : base(options)  
        { }  
  
        public DbSet<TodoItem> Todos { get; set; }  
    }  
}   