﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Base.RabbitMq
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMq(this IServiceCollection services, IConfigurationSection section)
        {
            // RabbitMQ Configuration
            var options = new RawRabbitConfiguration();
            section.Bind(options);

            var client = BusClientFactory.CreateDefault(options);
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}