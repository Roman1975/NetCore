using DoubleDbProvider.Domain.Models;
using Microsoft.EntityFrameworkCore;
using DoubleDbProvider.Domain;

namespace DoubleDbProvider.DomainPG
{
    public class PostgresDbContext : SqlDbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql("User ID=myapi;Password=111;Server=localhost;Port=5432;Database=doubleDbProvider;Integrated Security=true;Pooling=true;");
        //}

        protected override void DescribeDataTypes(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Todo>()
                .Property(prop => prop.Cost)
                .HasColumnType("money");
        }
    }
}