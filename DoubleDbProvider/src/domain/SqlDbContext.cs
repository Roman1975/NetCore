using DoubleDbProvider.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DoubleDbProvider.Domain
{
    public class SqlDbContext: DbContext
    {
        //public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        //{ }
        public SqlDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }
		public DbSet<Kind> Kinds { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("Todos");

			// props
			modelBuilder
				.Entity<Todo>()
				.Property(prop => prop.Title)
				.HasMaxLength(128)
				.IsRequired();
			modelBuilder
				.Entity<Todo>()
				.Property(prop => prop.CreateDate)
				.IsRequired();
			modelBuilder
				.Entity<Kind>()
				.Property(prop => prop.Name)
				.HasMaxLength(32)
				.IsRequired();

			DescribeDataTypes(modelBuilder);

			// links
			modelBuilder
				.Entity<Todo>()
	            .HasOne(o => o.Kind)
				.WithMany(m => m.Todos)
	            .HasForeignKey(k => k.KindId);
		}

		protected virtual void DescribeDataTypes(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Todo>()
	            .Property(prop => prop.Cost)
	            .HasColumnType("smallmoney");
		}

	}
}