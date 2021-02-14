using DateCounter.Core.Models;
using DateCounter.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DateCounter.Core.Tests.Services
{    
    public class BusinessDayCounterTests
    {
        [TestClass]
        public class WeekdaysBetweenTwoDates
        {
            [TestMethod]
            public void WeekdaysBetweenTwoDates_Should_Return_Expected_Data()
            {
                //Arrange
                var dateCounter = new BusinessDayCounter();
                var startDate1 = new DateTime(2013, 10, 7);
                var endDate1 = new DateTime(2013, 10, 9);
                var startDate2 = new DateTime(2013, 10, 5);
                var endDate2 = new DateTime(2013, 10, 14);
                var startDate3 = new DateTime(2013, 10, 7);
                var endDate3 = new DateTime(2014, 1, 1);
                var startDate4 = new DateTime(2013, 10, 7);
                var endDate4 = new DateTime(2013, 10, 5);

                //Act
                var weekDaysQty1 = dateCounter.WeekdaysBetweenTwoDates(startDate1, endDate1);
                var weekDaysQty2 = dateCounter.WeekdaysBetweenTwoDates(startDate2, endDate2);
                var weekDaysQty3 = dateCounter.WeekdaysBetweenTwoDates(startDate3, endDate3);
                var weekDaysQty4 = dateCounter.WeekdaysBetweenTwoDates(startDate4, endDate4);

                //Assert
                Assert.AreEqual(1, weekDaysQty1);
                Assert.AreEqual(5, weekDaysQty2);
                Assert.AreEqual(61, weekDaysQty3);
                Assert.AreEqual(0, weekDaysQty4);
            }
        }

        [TestClass]
        public class BusinessDaysBetweenTwoDates
        {
            [TestMethod]
            public void BusinessDaysBetweenTwoDates_Should_Return_Expected_Data()
            {
                //Arrange
                var dateCounter = new BusinessDayCounter();
                var publicHolidays = new List<DateTime>()
                {
                    new DateTime(2013,12,25),
                    new DateTime(2013,12,26),
                    new DateTime(2014,1,1)
                };
                var startDate1 = new DateTime(2013, 10, 7);
                var endDate1 = new DateTime(2013, 10, 9);
                var startDate2 = new DateTime(2013, 12, 24);
                var endDate2 = new DateTime(2013, 12, 27);
                var startDate3 = new DateTime(2013, 10, 7);
                var endDate3 = new DateTime(2014, 1, 1);

                //Act
                var businessDaysQty1 = dateCounter.BusinessDaysBetweenTwoDates(startDate1, endDate1, publicHolidays);
                var businessDaysQty2 = dateCounter.BusinessDaysBetweenTwoDates(startDate2, endDate2, publicHolidays);
                var businessDaysQty3 = dateCounter.BusinessDaysBetweenTwoDates(startDate3, endDate3, publicHolidays);
                
                //Assert
                Assert.AreEqual(1, businessDaysQty1);
                Assert.AreEqual(0, businessDaysQty2);
                Assert.AreEqual(59, businessDaysQty3);
            }

            [TestMethod]
            public void BusinessDaysBetweenTwoDates_Should_Return_Expected_Data_When_Receive_Customized_Holidays()
            {
                //Arrange
                var dateCounter = new BusinessDayCounter();
                var publicHolidays = new List<PublicHoliday>();
                publicHolidays.Add(new PublicHoliday() { 
                    Type = PublicHolidayType.SameDay,
                    DateOcurrence = new DateOcurrence()
                    {
                        Day = 25,
                        Month = Month.Apr
                    },
                    Name = "Anzac Day"
                });
                publicHolidays.Add(new PublicHoliday() { 
                    Type = PublicHolidayType.MondayIfWeekend,
                    DateOcurrence = new DateOcurrence()
                    {
                        Day = 1,
                        Month = Month.Jan
                    },
                    Name = "New Year's Day"
                });
                publicHolidays.Add(new PublicHoliday()
                {
                    Type = PublicHolidayType.ByOcurrence,
                    DateOcurrence = new DateOcurrence()
                    {
                        Type = OcurrenceType.Second,
                        WeekDay = DayOfWeek.Monday,
                        Month = Month.Jun
                    },
                    Name = "Queens Birthday"
                });
                publicHolidays.Add(new PublicHoliday()
                {
                    Type = PublicHolidayType.FixedDate,
                    Date = new DateTime(2013, 9, 6),
                    Name = "Random Date"
                });

                var startDate1 = new DateTime(2013, 4, 24);
                var endDate1 = new DateTime(2013, 4, 27);
                var startDate2 = new DateTime(2016, 12, 30);
                var endDate2 = new DateTime(2017, 1, 4);
                var startDate3 = new DateTime(2021, 6, 13);
                var endDate3 = new DateTime(2021, 6, 15);
                var startDate4 = new DateTime(2013, 1, 1);
                var endDate4 = new DateTime(2014, 1, 1);

                //Act
                var businessDaysQty1 = dateCounter.BusinessDaysBetweenTwoDates(startDate1, endDate1, publicHolidays);
                var businessDaysQty2 = dateCounter.BusinessDaysBetweenTwoDates(startDate2, endDate2, publicHolidays);
                var businessDaysQty3 = dateCounter.BusinessDaysBetweenTwoDates(startDate3, endDate3, publicHolidays);
                var businessDaysQty4 = dateCounter.BusinessDaysBetweenTwoDates(startDate4, endDate4, publicHolidays);

                //Assert
                Assert.AreEqual(1, businessDaysQty1);
                Assert.AreEqual(1, businessDaysQty2);
                Assert.AreEqual(0, businessDaysQty3);
                Assert.AreEqual(257, businessDaysQty4);
            }
        }
    }
}