using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bizminds.WebApp.Controllers
{
    public class PalindromeController : Controller
    {
        // GET: Palindrome
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Check(Models.PalindromeRequest model)
        {
            var chars = model.Value.ToLower().ToCharArray();
            var length = chars.Length;
            for(int index = 0; index < length / 2; index++)
            {
                if(chars[index] != chars[length - index - 1])
                {
                    return Json(new { IsValid = false });
                }
            }
            return Json(new { IsValid = true });
        }
    }
}