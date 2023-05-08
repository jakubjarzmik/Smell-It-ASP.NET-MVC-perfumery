using Microsoft.AspNetCore.Mvc;
using SmellIt.Website.Models;
using System.Diagnostics;
using MediatR;
using SmellIt.Application.SmellIt.Products.Queries.GetAllProducts;
using SmellIt.Application.SmellIt.Products.Queries.GetProductByEncodedName;

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
	public IActionResult Index()
    {
        return View();
    }
    [Route("products/{encodedName}")]
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