using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.Controllers.Abstract;

public abstract class BaseController : Controller
{
    protected IMediator Mediator { get; private set; }
    protected string Session => Application.Helpers.Session.GetSession(HttpContext);
    protected bool IsAuthenticated => User.Identity?.IsAuthenticated ?? false;
    protected string CurrentCulture =>
        HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString() ?? "en-GB";
    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}