using System.ComponentModel;

namespace DateCounter.Core.Models
{
    public enum OcurrenceType
    {
        [Description("First")]
        First,
        [Description("Second")]
        Second,
        [Description("Third")]
        Third,
        [Description("Fourth")]
        Fourth,
        [Description("Fifth")]
        Fifth
    }
}
