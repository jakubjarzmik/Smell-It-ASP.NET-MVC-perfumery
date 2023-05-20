using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.ProductCategories.Queries.GetAllProductCategoriesForWebsite;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents
{
    public class ProductCategoriesViewComponent : BaseViewComponent
    {
        public ProductCategoriesViewComponent(IMediator mediator) : base(mediator)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCategories =  await Mediator.Send(new GetAllProductCategoriesForWebsiteQuery(CurrentCulture));

            return View(productCategories);
        }
    }
}
