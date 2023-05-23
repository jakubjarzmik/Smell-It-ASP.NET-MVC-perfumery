using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using SmellIt.Application.Features.Products.Queries.GetFilteredProductsForWebsite;
using SmellIt.Application.Features.Products.Queries.GetProductByEncodedNameForWebsite;
using SmellIt.Website.Controllers.Abstract;
using Microsoft.Data.SqlClient;

namespace SmellIt.Website.Controllers;
public class ProductsController : BaseController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {

    }

    [Route("products")]
    public async Task<IActionResult> Index(SortType? sort_type, string? category, string? brand, string? gender, string? fragrance_category)
    {
        var products = await Mediator.Send(new GetFilteredProductsForWebsiteQuery
        {
            SortType = sort_type,
            CategoryEncodedName = category,
            BrandEncodedName = brand,
            GenderEncodedName = gender,
            FragranceCategoryEncodedName = fragrance_category,
            LanguageCode = CurrentCulture
        });
        return View(products);
    }

    [Route("products/{encodedName}/details")]
    public async Task<IActionResult> Details(string encodedName)
    {
        var product = await Mediator.Send(new GetProductByEncodedNameForWebsiteQuery(encodedName, CurrentCulture));
        return View(product);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}