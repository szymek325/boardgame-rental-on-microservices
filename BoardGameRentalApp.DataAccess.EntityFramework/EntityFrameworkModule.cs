using System.Reflection;
using System.Runtime.CompilerServices;
using BoardGameRentalApp.Core.Configuration;
using BoardGameRentalApp.Core.DataAccess;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using BoardGameRentalApp.DataAccess.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.DataAccess.EntityFramework
{
    public static class EntityFrameworkModule
    {
        public static IServiceCollection AddEntityFrameworkModule(this IServiceCollection services,
            ConnectionStrings connectionStrings)
        {
            services.AddDbContext<BoardGameRentalContext>(options => options.UseSqlServer(connectionStrings.MainDb,
                migrationsOptions =>
                    migrationsOptions.MigrationsAssembly(typeof(BoardGameRentalContext).GetTypeInfo().Assembly.GetName().Name)));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}