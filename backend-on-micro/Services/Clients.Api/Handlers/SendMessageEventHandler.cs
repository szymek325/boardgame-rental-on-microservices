using System;
using System.Threading;
using System.Threading.Tasks;
using Base.RabbitMq.Markers;
using Base.RabbitMq.Messages;

namespace Clients.Api.Handlers
{
    public class SendMessageEventHandler : IEventHandler<SendEvent>
    {
        public async Task HandleAsync(SendEvent @event, CancellationToken token)
        {
            Console.WriteLine($"Receive: {@event.Message}");
        }
    }
}