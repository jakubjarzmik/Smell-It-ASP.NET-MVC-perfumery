using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders;
using SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedName;
using SmellIt.Application.SmellIt.Products.Queries.GetProductsByCategoryEncodedName;
using SmellIt.Application.SmellIt.Products.Queries.GetAllProducts;
using SmellIt.Application.SmellIt.Products.Queries.GetFilteredProducts;

namespace SmellIt.Website.Controllers;
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _env;

    public ProductsController(IMediator mediator, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _env = env;
    }

    [Route("products")]
    public async Task<IActionResult> Index(string? category, string? brand, string? gender, string? fragranceCategory)
    {
        var products = await _mediator.Send(new GetFilteredProductsQuery
        {
            CategoryEncodedName = category,
            BrandEncodedName = brand,
            GenderEncodedName = gender,
            FragranceCategoryEncodedName = fragranceCategory
        });
        return View(products);
    }

    [Route("products/{encodedName}")]
	public async Task<IActionResult> Index(string encodedName)
    {
        var products = await _mediator.Send(new GetProductsByCategoryEncodedNameQuery(encodedName));
        return View(products);
    }

    [Route("products/details/{encodedName}")]
    public async Task<IActionResult> Details(string encodedName)
    {
	    var product = await _mediator.Send(new GetProductByEncodedNameQuery(encodedName));
        return View(product);
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}