using System.Reflection;
using System.Runtime.CompilerServices;
using BoardGameRentalApp.Core.Configuration;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqlServer.Context;
using BoardGameRentalApp.DataAccess.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.DataAccess.SqlServer
{
    public static class SqlServerModule
    {
        public static IServiceCollection AddSqlServerModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionStrings.SqlServer,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(SqlServerContext).GetTypeInfo().Assembly.GetName()
                        .Name)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}