using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netcore.Data;
using netcore.Models;
using netcore.Services;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace netcore
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
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<MyUser, MyRole>()
                .AddEntityFrameworkStores<MyDbContext>()
                .AddDefaultTokenProviders();
            
            // add application insight
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<MyDbContext>();
                //var userManager = services.GetRequiredService<UserManager<MyUser>>();
                //var roleManager = services.GetRequiredService<RoleManager<MyRole>>();

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();

                    try
                    {
                        //TodoContextInitializer.Seed(context);
                        logger.LogInformation("Database seeding complete");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
                else
                {
                   app.UseExceptionHandler("/Home/Error");
                   try
                    {
                        context.Database.Migrate();
                        logger.LogInformation("Database migration complete");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred while migrating the database.");
                    }
                }
            }    

            app.UseAuthentication();

            // read more here https://andrewlock.net/adding-cache-control-headers-to-static-files-in-asp-net-core/
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });            
        }
    }
}
