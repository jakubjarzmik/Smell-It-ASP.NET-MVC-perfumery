using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace SmellIt.Website.Controllers.Abstract
{
    public abstract class BaseController : Controller
    {
        protected IMediator Mediator { get; private set; }
        protected string CurrentCulture =>
            HttpContext.Features.Get<IRequestCultureFeature>()?.RequestCulture.Culture.ToString() ?? "en-GB";
        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
