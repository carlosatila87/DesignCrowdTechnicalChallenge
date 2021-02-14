using DateCounter.Core.Abstracts;
using DateCounter.Core.Models;
using DateCounter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DateCounter.Web.Controllers
{
    public class HomeController : Controller
    {        
        private readonly IBusinessDayCounter _businessDayCounter;

        public HomeController(IBusinessDayCounter businessDayCounter)
        {            
            _businessDayCounter = businessDayCounter;
        }

        public IActionResult Index()
        {
            //WeekdaysBetweenTwoDates
            var firstDate1 = new DateTime(2013, 10, 7);
            var secondDate1 = new DateTime(2013, 10, 9);
            var firstDate2 = new DateTime(2013, 10, 5);
            var secondDate2 = new DateTime(2013, 10, 14);
            var firstDate3 = new DateTime(2013, 10, 7);
            var secondDate3 = new DateTime(2014, 1, 1);
            var firstDate4 = new DateTime(2013, 10, 7);
            var secondDate4 = new DateTime(2013, 10, 5);            
            
            var weekDays = new List<ResponseDateModel>() { 
                new ResponseDateModel()
                {
                    FirstDate = firstDate1,
                    SecondDate = secondDate1,
                    BusinessDaysQuantity = _businessDayCounter.WeekdaysBetweenTwoDates(firstDate1,secondDate1)                    
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate2,
                    SecondDate = secondDate2,
                    BusinessDaysQuantity = _businessDayCounter.WeekdaysBetweenTwoDates(firstDate2,secondDate2)
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate3,
                    SecondDate = secondDate3,
                    BusinessDaysQuantity = _businessDayCounter.WeekdaysBetweenTwoDates(firstDate3,secondDate3)
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate4,
                    SecondDate = secondDate4,
                    BusinessDaysQuantity = _businessDayCounter.WeekdaysBetweenTwoDates(firstDate4,secondDate4)
                }
            };

            //BusinessDaysBetweenTwoDates V1            
            var firstDate5 = new DateTime(2013, 12, 24);
            var secondDate5 = new DateTime(2013, 12, 27);
            var publicHolidaysV1 = new List<DateTime>() {
                new DateTime(2013,12,25),
                new DateTime(2013,12,26),
                new DateTime(2014,1,1)
            };


            var businessDaysV1 = new List<ResponseDateModel>() {
                new ResponseDateModel()
                {
                    FirstDate = firstDate1,
                    SecondDate = secondDate1,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate1,secondDate1,publicHolidaysV1),
                    PublicHolidaysV1 = publicHolidaysV1
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate5,
                    SecondDate = secondDate5,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate5,secondDate5,publicHolidaysV1),
                    PublicHolidaysV1 = publicHolidaysV1
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate3,
                    SecondDate = secondDate3,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate3,secondDate3,publicHolidaysV1),
                    PublicHolidaysV1 = publicHolidaysV1
                }
            };

            //BusinessDaysBetweenTwoDates V2            
            var publicHolidaysV2 = new List<PublicHoliday>() {
                new PublicHoliday()
                {
                    Type = PublicHolidayType.SameDay,
                    DateOcurrence = new DateOcurrence()
                    {
                        Day = 25,
                        Month = Month.Apr
                    },
                    Name = "Anzac Day"
                },
                new PublicHoliday()
                {
                    Type = PublicHolidayType.MondayIfWeekend,
                    DateOcurrence = new DateOcurrence()
                    {
                        Day = 1,
                        Month = Month.Jan
                    },
                    Name = "New Year's Day"
                },
                new PublicHoliday()
                {
                    Type = PublicHolidayType.ByOcurrence,
                    DateOcurrence = new DateOcurrence()
                    {
                        Type = OcurrenceType.Second,
                        WeekDay = DayOfWeek.Monday,
                        Month = Month.Jun
                    },
                    Name = "Queen's Birthday"
                },
                new PublicHoliday()
                {
                    Type = PublicHolidayType.FixedDate,
                    Date = new DateTime(2013, 11, 10),
                    Name = "Custom Fixed Date Holiday"
                }
            };


            var businessDaysV2 = new List<ResponseDateModel>() {
                new ResponseDateModel()
                {
                    FirstDate = firstDate1,
                    SecondDate = secondDate1,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate1,secondDate1,publicHolidaysV2),
                    PublicHolidaysV2 = publicHolidaysV2
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate5,
                    SecondDate = secondDate5,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate5,secondDate5,publicHolidaysV2),
                    PublicHolidaysV2 = publicHolidaysV2
                },
                new ResponseDateModel()
                {
                    FirstDate = firstDate3,
                    SecondDate = secondDate3,
                    BusinessDaysQuantity = _businessDayCounter.BusinessDaysBetweenTwoDates(firstDate3,secondDate3,publicHolidaysV2),
                    PublicHolidaysV2 = publicHolidaysV2
                }
            };

            return View(new DateCounterViewModel()
            {
                Weekdays = weekDays,
                BusinessDaysV1 = businessDaysV1,
                BusinessDaysV2 = businessDaysV2
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}