using System.Collections.Generic;

namespace DateCounter.Web.Models
{
    public class DateCounterViewModel
    {
        public List<ResponseDateModel> Weekdays { get; set; }
        public List<ResponseDateModel> BusinessDaysV1 { get; set; }
        public List<ResponseDateModel> BusinessDaysV2 { get; set; }
    }
}