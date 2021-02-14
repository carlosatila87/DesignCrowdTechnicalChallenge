using DateCounter.Core.Models;
using System;
using System.Collections.Generic;

namespace DateCounter.Core.Abstracts
{
    public interface IBusinessDayCounter
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<PublicHoliday> publicHolidays);
    }
}