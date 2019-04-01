using Bizminds.Models;
using Bizminds.WebApp.Helper;
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
            
            Age age = (new AgeCalculator(request.DateOfBirth)).GetAge();

            return Json(new {Result = $"Age: {age.Years} Year(s) {age.Months} Month(s) {age.Weeks} Weeks {age.Days} Day(s) {age.Hours} Hour(s) {age.Minutes} Minutes {age.Seconds} Second(s)" });
        }
    }
}