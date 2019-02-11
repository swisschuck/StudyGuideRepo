using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

namespace RestAPIStudyGuide
{
    public class Startup
    {
        // notes that came with this file:
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc() // here we will add the mvc services
                    .AddMvcOptions(mvcSetupOptions =>
                    {
                        // we can setup the app to have the ability to return the response in different formats, the default is json but
                        // if a user requests the data in XML without this line they will always get back json
                        mvcSetupOptions.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                    })
                    .AddJsonOptions(jsonSetupOptions =>
                    {
                        // here we are defining how we want the default json serializer to operate. By default our property names will start with a
                        // lower case letter. we dont want that so here is where we can make that change globally.
                        if (jsonSetupOptions.SerializerSettings.ContractResolver != null)
                        {
                            var castedResolver = jsonSetupOptions.SerializerSettings.ContractResolver as DefaultContractResolver;

                            castedResolver.NamingStrategy = null; // when we set the naming strategy to null, the property names will come through exactly
                                                                  // as they are typed.
                        }
                    });

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


            // so if we have a bad request or some other problem the browser will not display this, the user would have to look at whats happening in the
            // browsers console window. When we add this line to the pipeline, .NET Core will use a simple text based system to show the user the status code
            // in the actual browser itself.
            app.UseStatusCodePages();


            // here we are adding the MVC middle ware to the request pipeline
            // its important to note that this was added AFTER the exception handler was added to the pipeline so we can catch any problems
            // before we hand off to the MVC.
            app.UseMvc();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
