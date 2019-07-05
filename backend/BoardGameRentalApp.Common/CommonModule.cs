using BoardGameRentalApp.Common.Common;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGameRentalApp.Common
{
    public static class CommonModule
    {
        public static IServiceCollection AddCommonModule(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}