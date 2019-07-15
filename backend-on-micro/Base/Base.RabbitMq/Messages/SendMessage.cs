using Base.RabbitMq.Markers;

namespace Base.RabbitMq.Messages
{
    public class SendMessage : IMessage
    {
        public SendMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}