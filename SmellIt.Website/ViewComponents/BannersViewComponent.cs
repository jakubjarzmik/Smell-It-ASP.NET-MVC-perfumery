using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;

namespace SmellIt.Website.ViewComponents
{
    public class BannersViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public BannersViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _mediator.Send(new GetAllHomeBannersQuery());

            return View(banners);
        }
    }
}
