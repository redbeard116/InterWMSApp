using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace InterWMSApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logConfigFilePath = $"Configurations/nlog.config";
                var logger = NLogBuilder.ConfigureNLog(logConfigFilePath).GetCurrentClassLogger();
                logger.Debug("init main");
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 config.SetBasePath(Directory.GetCurrentDirectory());
                 config.AddJsonFile("Configurations/AppConfig.json", true, true);
                 config.AddEnvironmentVariables();
                 config.AddCommandLine(args);
             })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            })
            .UseNLog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
