using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategories;

namespace SmellIt.Website.ViewComponents
{
    public class ProductCategoriesViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ProductCategoriesViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategories =  await _mediator.Send(new GetAllProductCategoriesQuery());

            return View(productCategories);
        }
    }
}
