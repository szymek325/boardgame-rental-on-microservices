using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;

namespace Base.Configuration
{
    public class CommonProgram
    {
        public static IConfigurationBuilder CreateConfigurationBuilder()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environment}.json", false, true);
        }

        public static ILogger GetLogger(IConfigurationRoot configuration)
        {
            var nlogConfigSection = configuration.GetSection("NLog");
            LogManager.Configuration = new NLogLoggingConfiguration(nlogConfigSection);
            ILogger logger = LogManager.GetCurrentClassLogger();
            return logger;
        }

        //public static void StartApp(string[] args, ILogger logger, IConfigurationRoot configuration)
        //{
        //    try
        //    {
        //        logger.Debug("Application started");
        //        CreateWebHostBuilder(args)
        //            .UseConfiguration(configuration)
        //            .Build()
        //            .Run();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error(ex, "Stopped program because of exception when building WebHost");
        //        throw;
        //    }
        //    finally
        //    {
        //        LogManager.Shutdown();
        //    }
        //}
    }
}