using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RestAPIStudyGuide
{
    public class Startup
    {
        // notes that came with this file:
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // here we will add some mvc
            services.AddMvc();
        }

        // notes that came with this file:
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // ch - adding DeveloperException "Middleware" in the pipeline
                // this is only added if the environment is in development
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // ch - if the app is not in dev mode then lets use the normal exception handler.
                app.UseExceptionHandler();
            }

            // here we are adding the MVC middle ware to the request pipeline
            // its important to note that this was added AFTER the exception handler was added to the pipeline so we can catch any problems
            // before we hand off to the MVC.
            app.UseMvc();
            //app.UseHttpsRedirection();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
