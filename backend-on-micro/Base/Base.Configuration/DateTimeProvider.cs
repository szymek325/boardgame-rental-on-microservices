using System;

namespace Base.Configuration
{
    public interface IDateTimeProvider
    {
        DateTime UtcDateTime();
    }

    internal class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}