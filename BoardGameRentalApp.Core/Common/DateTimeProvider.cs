using System;

namespace BoardGameRentalApp.Core.Common
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