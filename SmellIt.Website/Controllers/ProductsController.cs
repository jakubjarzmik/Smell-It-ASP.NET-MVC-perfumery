using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using SmellIt.Application.SmellIt.Products.Queries.GetFilteredProductsForWebsite;
using SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedNameForWebsite;
using SmellIt.Website.Controllers.Abstract;
using Microsoft.Data.SqlClient;

namespace SmellIt.Website.Controllers;
public class ProductsController : BaseController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {

    }

    [Route("products")]
    public async Task<IActionResult> Index(SortType? sortType, string? category, string? brand, string? gender, string? fragranceCategory)
    {
        var products = await Mediator.Send(new GetFilteredProductsForWebsiteQuery
        {
            SortType = sortType,
            CategoryEncodedName = category,
            BrandEncodedName = brand,
            GenderEncodedName = gender,
            FragranceCategoryEncodedName = fragranceCategory,
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