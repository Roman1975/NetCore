using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreapiwithpostgresql.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql.EntityFrameworkCore;

namespace coreapiwithpostgresql
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<TodoDbContext>(opts => opts.UseNpgsql(connectionString));

            // Add framework services.
            services.AddMvc(
                //opt => opt.Filters.Add(new RequireHttpsAttribute ())
            ).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            // Add API versioning https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
            services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // loggerFactory.AddDebug();

            app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "default",
                                    template: "api/{controller=Default}/{action=Get}/{id?}");
                });
        }
    }
}
