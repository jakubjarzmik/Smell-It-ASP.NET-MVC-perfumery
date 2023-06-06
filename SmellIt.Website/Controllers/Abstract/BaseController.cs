using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.Controllers.Abstract;

public abstract class BaseController : Controller
{
    protected IMediator Mediator { get; private set; }
    protected string Session => GetSession();

    protected string CurrentCulture =>
        HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString() ?? "en-GB";
    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
    private string GetSession()
    {
        if (HttpContext.Session.GetString("SessionId") == null)
        {
            if (!string.IsNullOrEmpty(HttpContext.User.Identity?.Name))
            {
                HttpContext.Session.SetString("SessionId", HttpContext.User.Identity.Name);
            }
            else
            {
                Guid tempSessionId = Guid.NewGuid();
                HttpContext.Session.SetString("SessionId", tempSessionId.ToString());
            }
        }
        return HttpContext.Session.GetString("SessionId")!;
    }
}