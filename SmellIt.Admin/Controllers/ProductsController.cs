using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Services;
using SmellIt.Domain.Entities;

namespace SmellIt.Admin.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IBrandService _brandService;

    public ProductsController(IProductService productService, IBrandService brandService)
    {
        _productService = productService;
        _brandService = brandService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Brands()
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

    [HttpPost("/Products/Brands")]
    public async Task<IActionResult> Create(Brand brand)
    {
        await _brandService.Create(brand);
        return RedirectToAction(nameof(Create)); // to do 
    }
}
