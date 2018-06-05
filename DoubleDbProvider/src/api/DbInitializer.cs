using DoubleDbProvider.Domain;
using DoubleDbProvider.Domain.Models;
using DoubleDbProvider.DomainPG;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DoubleDbProvider.API
{
    public static class DbInitializer
    {

        public static void Initialize(SqlDbContext context)
        {
            //if(context.Kinds == null)
            context.Database.EnsureCreated();

            if (context.Kinds.Any())
            {
                return;   // DB has been seeded
            }


            var kinds = new Kind[]{
                new Kind { Name = "dig"},
                new Kind { Name = "raw"}
            };
            context.Kinds.AddRange(kinds);
            context.SaveChanges();

            var now = DateTimeOffset.Now;
            var todos = new Todo[]{
                new Todo { Title = "test 1", CreateDate = now, Cost = 10M, Kind = kinds[0] },
                new Todo { Title = "test 2", CreateDate = now, Cost = 50M,  Kind = kinds[1]}
            };

            context.Todos.AddRange(todos);
            context.SaveChanges();
        }

        internal static void Initialize(IServiceProvider services)
        {
            var ctx = services.GetService<SqlDbContext>();
            ctx = ctx ?? services.GetService<PostgresDbContext>();

            ctx.Database.Migrate();
            Initialize(ctx);
        }
    }
}