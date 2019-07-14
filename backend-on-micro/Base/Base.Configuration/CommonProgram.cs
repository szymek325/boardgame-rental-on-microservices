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
    }
}