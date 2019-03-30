﻿using System;
using System.Reflection;
using BoardGameRentalApp.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BoardGameRentalApp.DataAccess.SqlServer.Context
{
    internal class BoardGameRentalContextFactory : IDesignTimeDbContextFactory<BoardGameRentalMsSqlContext>
    {
        public BoardGameRentalMsSqlContext CreateDbContext(string[] args)
        {
            var connectionString = GetConnectionString();

            var builder = new DbContextOptionsBuilder<BoardGameRentalMsSqlContext>();
            builder.UseSqlServer(
                connectionString.SqlServer,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(BoardGameRentalMsSqlContext).GetTypeInfo().Assembly.GetName()
                        .Name));

            return new BoardGameRentalMsSqlContext(builder.Options);
        }

        private static ConnectionStrings GetConnectionString()
        {
            var configuration = GetConfig();
            var connectionStrings = new ConnectionStrings();
            configuration.GetSection(nameof(ConnectionStrings)).Bind(connectionStrings);
            return connectionStrings;
        }

        public static IConfigurationRoot GetConfig()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var projectPath =
                AppDomain.CurrentDomain.BaseDirectory.Split(new[] {@"bin\"}, StringSplitOptions.None)[0];
            var configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();
            return configuration;
        }
    }
}