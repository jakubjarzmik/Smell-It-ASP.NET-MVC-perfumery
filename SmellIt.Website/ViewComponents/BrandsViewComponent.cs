using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.Brands.Queries.GetAllBrandsForWebsite;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;
public class BrandsViewComponent : BaseViewComponent
{
    public BrandsViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var brands = await Mediator.Send(new GetAllBrandsForWebsiteQuery(CurrentCulture));

        return View(brands);
    }
}
