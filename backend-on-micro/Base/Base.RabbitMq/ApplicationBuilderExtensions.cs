using System;
using System.Reflection;
using System.Threading;
using Base.RabbitMq.Markers;
using Microsoft.AspNetCore.Builder;
using RawRabbit;
using RawRabbit.Common;

namespace Base.RabbitMq
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder app, IBusClient client)
            where T : IEvent
        {
            if (!(app.ApplicationServices.GetService(typeof(IEventHandler<T>)) is IEventHandler<T> handler))
                throw new NullReferenceException();

            client
                .SubscribeAsync<T>(async (msg, context) => { await handler.HandleAsync(msg, CancellationToken.None); });
            return app;
        }

        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder app)
            where T : IEvent
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddEventHandler<T>(app, busClient);
        }

        public static ISubscription SubscribeToCommand<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler, string name = null) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandleAsync(msg, CancellationToken.None),
                cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TCommand>(name))));
        }

        public static ISubscription SubscribeToEvent<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler, string name = null) where TEvent : IEvent
        {
            return bus.SubscribeAsync<TEvent>(async (msg, context) => await handler.HandleAsync(msg, CancellationToken.None),
                cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TEvent>(name))));
        }

        private static string GetExchangeName<T>(string name = null)
        {
            return string.IsNullOrWhiteSpace(name)
                ? $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}"
                : $"{name}/{typeof(T).Name}";
        }
    }
}