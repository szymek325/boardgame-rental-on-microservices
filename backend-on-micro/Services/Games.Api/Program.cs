using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Games.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = BuildConfiguration();
            var nlogConfigSection = configuration.GetSection("NLog");
            LogManager.Configuration = new NLogLoggingConfiguration(nlogConfigSection);
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Debug("Application started");
                CreateWebHostBuilder(args)
                    .UseConfiguration(configuration)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception when building WebHost");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog();
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", false, true)
                .Build();
        }
    }
}