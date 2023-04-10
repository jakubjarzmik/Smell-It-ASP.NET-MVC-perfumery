using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Dtos;
using SmellIt.Application.Services.Interfaces;

namespace SmellIt.Admin.Controllers;
public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(BrandDto brandDto)
    {
        if (!ModelState.IsValid)
        {
            return View(brandDto);
        }

        await _brandService.Create(brandDto);
        return RedirectToAction(nameof(Index));
    }
}