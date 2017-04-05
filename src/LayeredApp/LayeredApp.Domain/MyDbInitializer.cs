using System;
using System.Linq;

namespace LayeredApp.Domain
{
    public static class MyDbInitializer
    {
        public static void Initialize(MyDbContext context)
        {
            //context.Database.EnsureCreated();
//            if (context.AllMigrationsApplied())
            {
                // Look for any students.
                if (context.Todos.Any())
                {
                    return;   // DB has been seeded
                }

                var todos = new TodoItem[]
                {
                new TodoItem { Title = "test 1", DateStart = DateTime.Now },
                new TodoItem { Title = "test 2", DateStart = DateTime.Now },
                new TodoItem { Title = "test 3", DateStart = DateTime.Now },
                };

                foreach (TodoItem t in todos)
                {
                    context.Todos.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}