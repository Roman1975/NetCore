using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaugeCommand.Domain;
using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GaugeCommand
{
    public class Startup
    {
        private const string ConnectionString = "Server=127.0.0.1;Port=5432;Database=api_doc;User Id=myapi;Password=111;";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName} .json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration["DbContextSettings:ConnectionString"];
            services.AddMvc();
            // db context
            services.AddDbContext<AppDbContext>(opts => opts.UseNpgsql(connString));
            // Marten document store
            services.AddScoped<IDocumentStore>(provider => 
                DocumentStore.For(connectionString: connString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
