using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebOptimizer
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
            // WebOptimizer works automatically!
            services.AddWebOptimizer();

            // https://github.com/ligershark/WebOptimizer
            // services.AddWebOptimizer(pipeline =>
            // {
            //     // files
            //     pipeline.MinifyJsFiles("js/a.js", "js/b.js", "js/c.js");
            //     // folders
            //     pipeline.MinifyCssFiles("css/**/*.css");
            //     // Bundling
            //     pipeline.AddCssBundle("/css/bundle.css", "css/a.css", "css/b.css");
            //     pipeline.AddCssBundle("/css/bundle.css", "css/*.css");
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // WebOptimizer!
            app.UseWebOptimizer();

            app.UseStaticFiles();
            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
