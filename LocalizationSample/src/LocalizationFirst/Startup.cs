using System.Linq;
using System.Threading.Tasks;
using LocalizationSample.Filters;
using LocalizationSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LocalizationSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            // todo: setup localization
            services.AddLocalization(ops => ops.ResourcesPath = "Resources");

            services.AddMvc(opts =>
            {
                opts.Conventions.Insert(0, new LocalizationConvention());
                opts.Filters.Add(new MiddlewareFilterAttribute(typeof(LocalizationPipeline)));
            })
            .AddDataAnnotationsLocalization()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(SupportedCultures.Items.Last()),
                SupportedCultures = SupportedCultures.Items,
                SupportedUICultures = SupportedCultures.Items
            };

            options.RequestCultureProviders = new[] {
                new RouteDataRequestCultureProvider()
                    {
                        RouteDataStringKey = "culture",
                        Options = options
                    }
                };

            services.AddSingleton(options);


            services.Configure<RouteOptions>(opts =>
                opts.ConstraintMap.Add("culturecode", typeof(CultureRouteConstraint)));

        }
        
              

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseResponseCompression();
            app.UseStaticFiles();


            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                           name: "default",
                           template: "{culture:culturecode}/{controller=Home}/{action=Index}/{id?}");

                routes.MapGet("{culture:culturecode}/{*path}", appBuilder => 
                    {
                        appBuilder.Response.StatusCode = 404;
                        return Task.FromResult(0);
                    });

                routes.MapGet("{*path}", (RequestDelegate)(ctx =>
                {
                    var defaultCulture = locOptions.Value.DefaultRequestCulture.Culture.Name;
                    var path = ctx.GetRouteValue("path") ?? string.Empty;
                    var culturedPath = $"{ctx.Request.PathBase}/{defaultCulture}/{path}";
                    //var culturedPath = $"/{defaultCulture}/{path}";
                    ctx.Response.Redirect(culturedPath);
                    return Task.CompletedTask;
                }));
            });            
        }
    }
}