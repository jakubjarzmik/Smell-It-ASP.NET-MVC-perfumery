using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.SocialSites.Queries.GetAllSocialSites;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents
{
    public class SocialSitesViewComponent : BaseViewComponent
    {

        public SocialSitesViewComponent(IMediator mediator) : base(mediator)
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialSites =  await Mediator.Send(new GetAllSocialSitesQuery());

            return View(socialSites);
        }
    }
}
