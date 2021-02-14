using System;

namespace DateCounter.Core.Models
{
    public class DateOcurrence
    {
        public OcurrenceType Type { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public int Day { get; set; }
        public Month Month { get; set; }
    }
}
