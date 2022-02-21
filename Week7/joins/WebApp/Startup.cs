using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Step 11. Add razor pages to the app...
            services.AddRazorPages();
            // End Step 11...
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Step 1. Add an else clause to secure server....
            else
            {
                app.UseHsts();
            }
            // End Step 1...

            app.UseRouting();

            // Step 2. Redirect client to secure server...
            app.UseHttpsRedirection();
            // End Step 2...

            // Step 6. Use default files...
            app.UseDefaultFiles();
            // End Step 6...

            // Step 7. Use static files...
            app.UseStaticFiles();
            // End Step 7.

            app.UseEndpoints(endpoints =>
            {
                // Step 5. Comment out endpoints...
                /*                 
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
                // End Step 5...
                // Step 12. Map razor pages...
                endpoints.MapRazorPages();
                // End Step 12...
            });
        }
    }
}
