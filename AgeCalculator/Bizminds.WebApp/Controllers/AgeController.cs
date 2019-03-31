using Bizminds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bizminds.WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Age
        [HttpGet]
        public ActionResult Age()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Age(AgeCalculatorRequest request)
        {
            DateTime now = DateTime.Now;
            int years = new DateTime(DateTime.Now.Subtract(request.DateOfBirth).Ticks).Year - 1;
            DateTime pastYearDate = request.DateOfBirth.AddYears(years);
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
            int days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            int weeks = days / 7;
            days = days % 7;
            int hours = now.Subtract(pastYearDate).Hours;
            int minutes = now.Subtract(pastYearDate).Minutes;
            int seconds = now.Subtract(pastYearDate).Seconds;

            return Json(new {Result = $"Age: {years} Year(s) {months} Month(s) {weeks} Weeks {days} Day(s) {hours} Hour(s) {minutes} Minutes {seconds} Second(s)" });
        }
    }
}