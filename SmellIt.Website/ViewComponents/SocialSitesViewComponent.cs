using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetAllSocialSites;
using SmellIt.Domain.Entities;

namespace SmellIt.Website.ViewComponents
{
    public class SocialSitesViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public SocialSitesViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socialSites =  await _mediator.Send(new GetAllSocialSitesQuery());

            return View(socialSites);
        }
    }
}
