using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DoubleDbProvider.Domain
{
    /// <summary>
    /// to read https://docs.microsoft.com/en-us/ef/core/miscellaneous/configuring-dbcontext
    /// </summary>
    public class SqlContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
    {
        public SqlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var connString = configuration["DbContextSettings:SqlLocal"];

            var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();

            optionsBuilder.UseSqlServer(connString, 
                b => b.MigrationsAssembly("DoubleDbProvider.Domain"));

            return new SqlDbContext(optionsBuilder.Options);
        }
    }
}
