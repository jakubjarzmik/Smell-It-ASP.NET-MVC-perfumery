using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Services.Interfaces;

namespace SmellIt.Admin.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Categories()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
}
