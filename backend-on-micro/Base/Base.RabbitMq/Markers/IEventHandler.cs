﻿using System.Threading;
using System.Threading.Tasks;

namespace Base.RabbitMq.Markers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken token);
    }
}