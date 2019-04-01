using Bizminds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizminds.WebApp.Helper
{
    public static class DateTimeHandler
    {
        
        public static DateDifference DateDifference(this DateTime fromDate, DateTime toDate)
        {
            if (fromDate == DateTime.MinValue)
                throw new Exception("Please enter valid date");
            if (toDate < fromDate)
                throw new Exception("To date should be greater than From date");
            DateDifference difference = new DateDifference();
            difference.Years = new DateTime(toDate.Subtract(fromDate).Ticks).Year - 1;
            DateTime pastYearDate = fromDate.AddYears(difference.Years);
            int months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (pastYearDate.AddMonths(i) == toDate)
                {
                    months = i;
                    break;
                }
                else if (pastYearDate.AddMonths(i) >= toDate)
                {
                    months = i - 1;
                    break;
                }
            }
            difference.Months = months;
            int days = toDate.Subtract(pastYearDate.AddMonths(months)).Days;
            difference.Weeks = days / 7;
            difference.Days = days % 7;
            difference.Hours = toDate.Subtract(pastYearDate).Hours;
            difference.Minutes = toDate.Subtract(pastYearDate).Minutes;
            difference.Seconds = toDate.Subtract(pastYearDate).Seconds;
            return difference;
        }
    }
}