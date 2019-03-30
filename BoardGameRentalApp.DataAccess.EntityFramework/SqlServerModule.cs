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
        public static IServiceCollection AddEntityFrameworkModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<BoardGameRentalContext>(options => options.UseSqlServer(connectionStrings.SqlServer,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(BoardGameRentalContext).GetTypeInfo().Assembly.GetName()
                        .Name)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}