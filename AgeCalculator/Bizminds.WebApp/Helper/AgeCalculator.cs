using Bizminds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizminds.WebApp.Helper
{
    public class AgeCalculator
    {
        private DateTime _date { get; set; }
        public AgeCalculator(DateTime date)
        {
            this._date = date;
        }

        public Age GetAge()
        {
            if (_date == DateTime.MinValue)
                throw new Exception("Please enter valid date");
            Age age = new Age();
            DateTime now = DateTime.Now;
            age.Years = new DateTime(DateTime.Now.Subtract(_date).Ticks).Year - 1;
            DateTime pastYearDate = _date.AddYears(age.Years);
            int months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (pastYearDate.AddMonths(i) == now)
                {
                    months = i;
                    break;
                }
                else if (pastYearDate.AddMonths(i) >= now)
                {
                    months = i - 1;
                    break;
                }
            }
            age.Months = months;
            int days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            age.Weeks = days / 7;
            age.Days = days % 7;
            age.Hours = now.Subtract(pastYearDate).Hours;
            age.Minutes = now.Subtract(pastYearDate).Minutes;
            age.Seconds = now.Subtract(pastYearDate).Seconds;
            return age;
        }
    }
}