using System.ComponentModel;

namespace DateCounter.Core.Models
{
    public enum PublicHolidayType
    {
        [Description("Same day")]
        SameDay,
        [Description("Same day or Monday if Weekend")]
        MondayIfWeekend,
        [Description("By Ocurrence")]
        ByOcurrence,
        [Description("Fixed Date")]
        FixedDate
    }
}
