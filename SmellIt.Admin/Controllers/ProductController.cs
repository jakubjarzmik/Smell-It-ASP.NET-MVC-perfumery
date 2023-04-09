using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Services;
using SmellIt.Domain.Entities;

namespace SmellIt.Admin.Controllers;
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost]
    public async IActionResult Create(Product product)
    {
        await _productService.Create(product);
    }
}
