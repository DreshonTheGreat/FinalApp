using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FirstProjectAPI_SANDERS
{
    public class Program
    {
        static InMemoryChannel channel = new InMemoryChannel();
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            Thread.Sleep(20000);
            channel.Flush();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                // clear default logging providers
                // logging.ClearProviders();
                // add built-in providers manually, as needed
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventLog();
                logging.AddEventSourceLogger();
            });
    }
}
