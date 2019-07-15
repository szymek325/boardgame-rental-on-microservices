using System;
using System.Threading;
using System.Threading.Tasks;
using Base.RabbitMq.Markers;
using Base.RabbitMq.Messages;

namespace Clients.Api.Handlers
{
    public class SendMessageHandler : IHandler<SendMessage>
    {
        public async Task HandleAsync(SendMessage @event, CancellationToken token)
        {
            Console.WriteLine($"Receive: {@event.Message}");
        }
    }
}