using System.Reflection;
using BoardGameRentalApp.Core.Configuration;
using BoardGameRentalApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}