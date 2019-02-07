using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StudyGuideRestAPI
{
    public class Program
    {
        // ASP.CORE is a console application at its core. To be more specific its a Console application that calls into ASP.NET libraries
        // The main method is responsible for configuring and running the application
        public static void Main(string[] args)
        {
            // here they are creating an instance of the web host
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
    }
}
