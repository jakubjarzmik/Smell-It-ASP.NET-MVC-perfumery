using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Localization;
using SmellIt.Application.Features.PrivacyPolicies.Queries.GetPrivacyPolicyByLanguageCode;
using SmellIt.Website.Controllers.Abstract;

namespace SmellIt.Website.Controllers;

public class HomeController : BaseController
{
    public HomeController(IMediator mediator) : base(mediator)
    {
    }
    public IActionResult Index()
    {
        return View();
    }

    [Route("page-not-found")]
    public IActionResult PageNotFound()
    {
        return View();
    }

    [Route("contact")]
    public IActionResult Contact()
    {
        return View();
    }

    [Route("privacy-policy")]
    public async Task<IActionResult> Privacy()
    {
        var privacyPolicy = await Mediator.Send(new GetPrivacyPolicyByLanguageCodeQuery(CurrentCulture));
        return View(privacyPolicy);
    }
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions(){Expires = DateTimeOffset.Now.AddYears(1)});

        return Redirect(Request.Headers["Referer"].ToString());
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}