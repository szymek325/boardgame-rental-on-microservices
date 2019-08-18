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
        public static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder app)
            where T : ICommand
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddCommandHandler<T>(app, busClient);
        }

        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder app)
            where T : IEvent
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddEventHandler<T>(app, busClient);
        }

        private static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder app, IBusClient client)
            where T : IEvent
        {
            if (!(app.ApplicationServices.GetService(typeof(IEventHandler<T>)) is IEventHandler<T> handler))
                throw new NullReferenceException();

            client.SubscribeToEvent(handler);
            return app;
        }

        private static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder app, IBusClient client)
            where T : ICommand
        {
            if (!(app.ApplicationServices.GetService(typeof(ICommandHandler<T>)) is ICommandHandler<T> handler))
                throw new NullReferenceException();

            client.SubscribeToCommand(handler);
            return app;
        }

        private static ISubscription SubscribeToCommand<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler, string name = null) where TCommand : ICommand
        {
            return bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandleAsync(msg, CancellationToken.None),
                cfg => cfg.WithQueue(q => q.WithName(GetExchangeName<TCommand>(name))));
        }

        private static ISubscription SubscribeToEvent<TEvent>(this IBusClient bus,
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