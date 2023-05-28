using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.HomeBanners.Queries.GetAllHomeBannersForWebsite;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;

public class BannersViewComponent : BaseViewComponent
{
    public BannersViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var banners = await Mediator.Send(new GetAllHomeBannersForWebsiteQuery(CurrentCulture));

        return View(banners);
    }
}