using System;

namespace BoardGameRentalApp.Common.Common
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