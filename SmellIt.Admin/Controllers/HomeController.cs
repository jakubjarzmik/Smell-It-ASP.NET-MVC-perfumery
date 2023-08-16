using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Authorization;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Home.Queries.GetHomeData;

namespace SmellIt.Admin.Controllers;

public class HomeController : BaseController
{
    public HomeController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [Authorize(Roles = "Admin,Employee")]
    public async Task<IActionResult> Index()
    {
        var viewModel = await Mediator.Send(new GetHomeDataQuery(CurrentCulture));
        return View(viewModel);
    }
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions() { Expires = DateTimeOffset.Now.AddYears(1) });

        return Redirect(Request.Headers["Referer"].ToString());
    }
}