using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmellIt.Application.Dtos;
using SmellIt.Application.Services.Interfaces;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 6; // Ustaw liczbę elementów na stronę

        var brands = await _brandService.GetAll();

        var paginatedBrands = brands
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)brands.Count() / pageSize);

        var viewModel = new BrandsViewModel
        {
            NewBrand = new BrandDto(),
            Brands = paginatedBrands,
            CurrentPage = pageNumber,
            TotalPages = totalPages,
            PageSize = pageSize

        };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Index(BrandsViewModel brandsViewModel)
    {
        var brandDto = brandsViewModel.NewBrand;
        if (!ModelState.IsValid)
        {
            return View(brandDto);
        }

        await _brandService.Create(brandDto);
        return RedirectToAction(nameof(Index));
    }
}