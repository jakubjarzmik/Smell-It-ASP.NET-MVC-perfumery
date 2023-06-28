using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.Products.Queries.GetMostPopularProducts;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;
public class MostPopularProductsViewComponent : BaseViewComponent
{
    public MostPopularProductsViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var products = await Mediator.Send(new GetMostPopularProductsQuery(CurrentCulture));

        return View(products);
    }
}
