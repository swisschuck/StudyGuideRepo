using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RestAPIStudyGuide
{
    // program is the starting point of our application. ASP.NET is at its core is a console application that talks to ASP.NET libraries.
    public class Program
    {
        // The main method is responsible for configuring and running the application
        public static void Main(string[] args)
        {
            // creating the web application host
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        // UseStartup - specifies the startup type that the application should start with.
    }
}
