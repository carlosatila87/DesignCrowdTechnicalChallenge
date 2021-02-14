using DateCounter.Core.Abstracts;
using System;
using System.Collections.Generic;
using DateCounter.Core.Extensions;
using DateCounter.Core.Models;

namespace DateCounter.Core.Services
{
    public class BusinessDayCounter : IBusinessDayCounter
    {
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            return CountBusinessDays(firstDate, secondDate, publicHolidays);
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<PublicHoliday> publicHolidays)
        {
            var adjustedHolidays = SetPublicHolidayDates(firstDate, secondDate, publicHolidays);
            return CountBusinessDays(firstDate, secondDate, adjustedHolidays);
        }

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            return CountBusinessDays(firstDate, secondDate);
        }

        private int CountBusinessDays(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays = null)
        {
            if (secondDate <= firstDate)
                return 0;
            if (publicHolidays == null)
                publicHolidays = new List<DateTime>();
            var dayQty = 0;
            for (var date = firstDate.AddDays(1); date < secondDate; date = date.AddDays(1))
            {
                if (!date.IsWeekendDay() && !publicHolidays.Contains(date))
                    dayQty++;
            }
            return dayQty;
        }

        private IList<DateTime> SetPublicHolidayDates(DateTime firstDate, DateTime secondDate, IList<PublicHoliday> publicHolidays)
        {
            if (secondDate <= firstDate)
                return null;

            var startYear = firstDate.Year;
            var finalYear = secondDate.Year;
            var adjustedHolidays = new List<DateTime>();
            foreach (var publicHoliday in publicHolidays)
            {
                switch (publicHoliday.Type)
                {
                    case PublicHolidayType.SameDay:
                        {
                            for (var year = startYear; year <= finalYear; year++)
                            {
                                try
                                {
                                    adjustedHolidays.Add(new DateTime(year, (int)publicHoliday.DateOcurrence.Month, publicHoliday.DateOcurrence.Day));
                                }
                                catch { }
                            }                                
                            break;
                        }                        
                    case PublicHolidayType.MondayIfWeekend:
                        {
                            for (var year = startYear; year <= finalYear; year++)
                            {
                                try
                                {
                                    var adjustedHoliday = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, publicHoliday.DateOcurrence.Day);
                                    if (adjustedHoliday.IsWeekendDay())
                                        adjustedHolidays.Add(adjustedHoliday.DayOfWeek == DayOfWeek.Saturday ? adjustedHoliday.AddDays(2) : adjustedHoliday.AddDays(1));
                                    else
                                        adjustedHolidays.Add(adjustedHoliday);

                                }
                                catch { }
                            }
                            break;                            
                        }                        
                    case PublicHolidayType.ByOcurrence:
                        {
                            for (var year = startYear; year <= finalYear; year++)
                            {
                                switch (publicHoliday.DateOcurrence.Type)
                                {
                                    case OcurrenceType.First:
                                        {
                                            var monthStartDate = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, 1);
                                            adjustedHolidays.Add(GetNextWeekDayDate(monthStartDate, publicHoliday.DateOcurrence.WeekDay));
                                            break;
                                        }
                                    case OcurrenceType.Second:
                                        {
                                            var monthStartDate = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, 8);
                                            adjustedHolidays.Add(GetNextWeekDayDate(monthStartDate, publicHoliday.DateOcurrence.WeekDay));
                                            break;
                                        }
                                    case OcurrenceType.Third:
                                        {
                                            var monthStartDate = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, 15);
                                            adjustedHolidays.Add(GetNextWeekDayDate(monthStartDate, publicHoliday.DateOcurrence.WeekDay));
                                            break;
                                        }
                                    case OcurrenceType.Fourth:
                                        {
                                            var monthStartDate = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, 22);
                                            adjustedHolidays.Add(GetNextWeekDayDate(monthStartDate, publicHoliday.DateOcurrence.WeekDay));
                                            break;
                                        }
                                    case OcurrenceType.Fifth:
                                        {
                                            var monthStartDate = new DateTime(year, (int)publicHoliday.DateOcurrence.Month, 29);
                                            var nextDate = GetNextWeekDayDate(monthStartDate, publicHoliday.DateOcurrence.WeekDay);
                                            if (nextDate.Month == monthStartDate.Month)
                                                adjustedHolidays.Add(nextDate);
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case PublicHolidayType.FixedDate:
                        {
                            adjustedHolidays.Add(publicHoliday.Date);
                            break;
                        }
                }
            }
            return adjustedHolidays;
        }

        private DateTime GetNextWeekDayDate(DateTime startDate, DayOfWeek weekDay)
        {
            if (startDate.DayOfWeek == weekDay)
                return startDate;
            else if (startDate.DayOfWeek > weekDay)
            {
                var dayDiff = (int)weekDay + 7 - (int)startDate.DayOfWeek;
                return startDate.AddDays(dayDiff);
            }
            else
            {
                var dayDiff = (int)weekDay - (int)startDate.DayOfWeek;
                return startDate.AddDays(dayDiff);
            }
        }
    }
}