using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Brands.Queries.GetAllBrands;

namespace SmellIt.Website.ViewComponents;
public class BrandsViewComponent : ViewComponent
{
    private readonly IMediator _mediator;

    public BrandsViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var brands = await _mediator.Send(new GetAllBrandsQuery());

        return View(brands);
    }
}
