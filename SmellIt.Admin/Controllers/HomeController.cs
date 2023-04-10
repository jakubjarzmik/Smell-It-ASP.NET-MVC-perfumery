using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Localization;

namespace SmellIt.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
	        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
		        CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
		        new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

	        return Redirect(Request.Headers["Referer"].ToString());
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}