using System;
using System.Threading;
using System.Threading.Tasks;

namespace Base.RabbitMq.Messages
{
    public class SendMessageHandler : IHandler<SendMessage>
    {
        public async Task HandleAsync(SendMessage @event, CancellationToken token)
        {
            Console.WriteLine($"Receive: {@event.Message}");
        }
    }
}