using Base.RabbitMq.Markers;

namespace Base.RabbitMq.Messages
{
    public class SendEvent : IEvent
    {
        public SendEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}