using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Products.Queries.GetAllProducts;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetAllSocialSites;

namespace SmellIt.Website.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProductsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products =  await _mediator.Send(new GetAllProductsQuery());

            return View(products);
        }
    }
}
