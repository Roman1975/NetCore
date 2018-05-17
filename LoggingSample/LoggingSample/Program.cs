using System;
using System.IO;
using LoggingSample.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddCommandLine(args);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));                    
                    logging.AddConsole(options => options.IncludeScopes = true); // todo: remove after asp.net core #2.1 released
                    logging.AddDebug();
                    logging.AddAzureWebAppDiagnostics();
                })
                .UseStartup<Startup>()
                .Build();



            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                var context = services.GetRequiredService<TodoContext>();
                var env = services.GetRequiredService<IHostingEnvironment>();

                try
                {
                    context.Database.Migrate();
                    logger.LogInformation("Database migration complete");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }

                if (env.IsDevelopment())
                {
                    try
                    {
                        TodoContextInitializer.Seed(context);
                        logger.LogInformation("Database seeding complete");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
            }

            webHost.Run();
        }

    }
}
