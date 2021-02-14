using DateCounter.Core.Models;
using System;
using System.Collections.Generic;

namespace DateCounter.Web.Models
{
    public class ResponseDateModel
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
        public List<DateTime> PublicHolidaysV1 { get; set; }
        public List<PublicHoliday> PublicHolidaysV2 { get; set; }
        public int BusinessDaysQuantity { get; set; }
    }
}
