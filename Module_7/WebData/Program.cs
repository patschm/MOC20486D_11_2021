using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureLogging(opts=> {
                        opts.AddConsole();
                        
                    });
                    webBuilder.ConfigureAppConfiguration(cb =>
                    {
                        //cb.AddJsonFile("appsettings.prod.json");
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
