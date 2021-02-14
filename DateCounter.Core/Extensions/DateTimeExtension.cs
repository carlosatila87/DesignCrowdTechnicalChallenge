using System;
using System.Collections.Generic;

namespace DateCounter.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static bool IsWeekendDay(this DateTime dateTime)
        {
            return (new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday }).Contains(dateTime.DayOfWeek);
        }
    }
}
