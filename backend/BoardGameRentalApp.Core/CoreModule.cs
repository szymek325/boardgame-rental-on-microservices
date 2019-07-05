using System.Runtime.CompilerServices;
using BoardGameRentalApp.Common;
using BoardGameRentalApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services)
        {
            services.AddTransient<IBoardGamesService, BoardGamesService>();
            services.AddTransient<IClientsService, ClientsService>();
            services.AddTransient<IGameRentalsService, GameRentalsService>();
            services.AddCommonModule();
            return services;
        }
    }
}