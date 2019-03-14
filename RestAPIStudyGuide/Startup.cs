using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using RestAPIStudyGuide.EntityFramework.Context.Other;
using RestAPIStudyGuide.EntityFramework.Extensions;
using RestAPIStudyGuide.Services.Other;
using System;
using System.Data.SqlClient;

namespace RestAPIStudyGuide
{
    public class Startup
    {

        #region fields

        //private string _sqlConnectionString = @"Data Source=CHARLIESHPENVY\CHARLIESQL2017;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Authentication=&quot;Active Directory Integrated&quot;; ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string _sqlConnectionString = @"Data Source=CHARLIESHPENVY\CHARLIESQL2017;Database=CityInfoDB;Trusted_Connection=True;Integrated Security=True;";

        #endregion fields


        #region Properties

        public static IConfigurationRoot Configuration;
        //public IConfiguration Configuration2; // we can use this interface instead if we want access to our configuration object

        #endregion Properties


        #region Constructors

        //public Startup(IConfiguration configuration) // see above property Configuration2 notes.
        public Startup(IHostingEnvironment environment)
        {
            // if we want to perform more actions that would happen at start up we can add a constructor to this class and inject them here.

            // here we are setting up a config file to be used with the application.
            // we can set different config files for different environments or for whatever reason we want.
            // these config files will get loaded in, in the order specified here.
            var builder = new ConfigurationBuilder()
                            .SetBasePath(environment.ContentRootPath)
                            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true) // by making this one not optional, it will be the default
                            .AddJsonFile($"appSettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true) // we can also plug the environment value in like this 
                            .AddEnvironmentVariables();

            // then storing those config values in the Configuration container from anywhere in the app.
            Configuration = builder.Build();
        }

        #endregion Constructors



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

            #region custom services
            // when we add a new service we can specify the lifetime of the service like so:

            // services.AddTransient - the service will get created each time its requested, works best for lightweight stateless services.
            // services.AddScoped - the service will get created once per request.
            // services.AddSingleton - are created the first time they are requested but each service request will use the same instance.

            //services.AddTransient<LocalMailService>(); // we can add the service as a concrete implementation.

            //services.AddTransient<IMailService, LocalMailService>(); // we can add the service coupled with an Interface.

#if DEBUG // we can also switch between the two types depending on if we're in debug mode or not.
            services.AddTransient<IMailService, LocalMailService>();
#else
                        services.AddTransient<IMailService, CloudMailService>();
#endif

            #endregion custom services

            // here we need to register our DBContext's that we will use with the Entity Framework. By default it will get registered with a
            // scope lifetime
            //services.AddDbContext<CityInfoDBContext>(); // this is the way if you wanted to define the options in each of the context
            SqlConnectionStringBuilder myLocalDB = new SqlConnectionStringBuilder()
            {
                DataSource = @"CHARLIESHPENVY\CHARLIESQL2017",
                InitialCatalog = "CityInfoDB",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };

            // getting the connection string from the appSettings.json file instead of building it out above. this will be needed to switch environments from development to production.
            // in the project properties, there is a section for environment variables, it will take the most recent one
            string connectionStringFromConfigFile = Startup.Configuration["connectionStrings:cityInfoDBConnectionString"];

            // here we can define the options once and apply to all DB contexts
            services.AddDbContext<CityInfoDBContext>(options => options.UseSqlServer(myLocalDB.ConnectionString));

            // for repositories, its based to use a scoped lifetime
            services.AddScoped<ICityInfoRepository, CityInfoRepository>();

        }

        // notes that came with this file:
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoDBContext cityInfoDBContext)
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

            // adds the ability to log to the console window.
            loggerFactory.AddConsole();

            // adds the ability to log to the debug window, LogLevel.Information is the default.
            loggerFactory.AddDebug(LogLevel.Information);

            // adds the ability to use NLog in our application so logs can be logged to an actual file
            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider()); // here is one way to do it.
            loggerFactory.AddNLog(); // however some extension libraries have their own built/slightly easier way to add this to your application.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // here we are using the passed in context (dependency injection) and calling our extension method to ensure we are seeding the data if its not already there
            cityInfoDBContext.EnsureSeedDataForContext();

            // so if we have a bad request or some other problem the browser will not display this, the user would have to look at whats happening in the
            // browsers console window. When we add this line to the pipeline, .NET Core will use a simple text based system to show the user the status code
            // in the actual browser itself.
            app.UseStatusCodePages();


            // configuring auto mapper to map our entities to our dto's so we dont have to do this everywhere
            AutoMapper.Mapper.Initialize(cfg =>
            {
                // source is the first type, second is the target
                cfg.CreateMap<EntityFramework.Entities.Other.CityEntity, Models.Other.CityWithoutPointsOfInterestDto>();
                cfg.CreateMap<EntityFramework.Entities.Other.CityEntity, Models.Other.CityDto>();
                cfg.CreateMap<EntityFramework.Entities.Other.PointOfInterestEntity, Models.Other.PointOfInterestDto>();
                cfg.CreateMap<Models.Other.PointOfInterestForCreationDto, EntityFramework.Entities.Other.PointOfInterestEntity>();
            });


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
