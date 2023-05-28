using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.ViewComponents.Abstract;

public abstract class BaseViewComponent : ViewComponent
{
    protected IMediator Mediator { get; private set; }
    protected string CurrentCulture =>
        HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString() ?? "en-GB";
    protected BaseViewComponent(IMediator mediator)
    {
        Mediator = mediator;
    }
}