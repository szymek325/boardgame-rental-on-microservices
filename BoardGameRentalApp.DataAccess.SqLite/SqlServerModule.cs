using System.Reflection;
using System.Runtime.CompilerServices;
using BoardGameRentalApp.Core.Configuration;
using BoardGameRentalApp.Core.Interfaces.DataAccess;
using BoardGameRentalApp.DataAccess.SqLite.Context;
using BoardGameRentalApp.DataAccess.SqLite.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.DataAccess.SqLite
{
    public static class SqlServerModule
    {
        public static IServiceCollection AddSqLiteModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<SqLiteContext>(options => options.UseSqlite(connectionStrings.SqLite,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(SqLiteContext).GetTypeInfo().Assembly.GetName()
                        .Name)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}