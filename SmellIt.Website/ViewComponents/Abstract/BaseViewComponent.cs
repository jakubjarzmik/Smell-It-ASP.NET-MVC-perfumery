using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.ViewComponents.Abstract;

public abstract class BaseViewComponent : ViewComponent
{
    protected IMediator Mediator { get; private set; }
    protected string CurrentCulture =>
        HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString() ?? "en-GB";
    protected string Session => GetSession();
    protected BaseViewComponent(IMediator mediator)
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