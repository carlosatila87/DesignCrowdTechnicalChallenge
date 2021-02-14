using System;

namespace DateCounter.Core.Models
{
    public class PublicHoliday
    {
        public string Name { get; set; }
        public PublicHolidayType Type { get; set; }
        public DateTime Date { get; set; }
        public DateOcurrence DateOcurrence { get; set; }        
    }
}
