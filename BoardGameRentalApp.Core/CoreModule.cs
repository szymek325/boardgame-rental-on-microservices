using System.Runtime.CompilerServices;
using BoardGameRentalApp.Core.Common;
using BoardGameRentalApp.Core.DataAccess;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace BoardGameRentalApp.Core
{
    public static class CoreModule
    {
        public static IServiceCollection AddCoreModule(this IServiceCollection services, IUnitOfWork a)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}