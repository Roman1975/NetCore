using DoubleDbProvider.Domain;
using DoubleDbProvider.DomainPG;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DoubleDbProvider.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // TODO: comment one section for one provider and vise versa
            var useSql = Convert.ToBoolean(Configuration["DbContextSettings:UseSql"]);
            if (!useSql)
            {
                var connString = Configuration["DbContextSettings:Postgres"];

                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<PostgresDbContext>(opts =>
                        opts.UseNpgsql(connString,
                            b => b.MigrationsAssembly("DoubleDbProvider.DomainPG")));
            }
            else
            {
                var connString2 = Configuration["DbContextSettings:SqlLocal"];

                services.AddEntityFrameworkSqlServer()
                    .AddDbContext<SqlDbContext>(opts =>
                        opts.UseSqlServer(connString2,
                            b => b.MigrationsAssembly("DoubleDbProvider.Domain")));

            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)//, DbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            // DbInitializer.Initialize(context);
        }
    }
}
