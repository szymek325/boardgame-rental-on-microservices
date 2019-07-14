﻿using System;
using Base.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

namespace Gateway.Api.Ocelot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = CommonProgram.CreateConfigurationBuilder()
                .AddJsonFile("ocelot.json", false, true)
                .Build();
            var logger = CommonProgram.GetLogger(configuration);

            StartApp(args, logger, configuration);
        }
        public static void StartApp(string[] args, ILogger logger, IConfigurationRoot configuration)
        {
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
    }
}