using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Localization;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;
using SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetAllPrivacyPolicies;
using SmellIt.Application.SmellIt.PrivacyPolicies.Queries.GetPrivacyPolicyByLanguageCode;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetAllSocialSites;
using SmellIt.Website.Helpers;

namespace SmellIt.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public HomeController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
            ;
        }

        public async Task<IActionResult> Index()
        {
            var banners = (await _mediator.Send(new GetAllHomeBannersQuery()));

            BannerImageManager.DeleteNonExistentBanners(banners, _env);

            ViewBag.Banners = banners;
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var currentCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>()!.RequestCulture.Culture.ToString();
            var privacyPolicy = await _mediator.Send(new GetPrivacyPolicyByLanguageCodeQuery(currentCulture));
            return View(privacyPolicy);
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions(){Expires = DateTimeOffset.UtcNow.AddYears(1)});

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}