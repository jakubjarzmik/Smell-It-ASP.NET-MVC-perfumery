using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.Brands.Queries.GetAllBrands;
using SmellIt.Application.SmellIt.Brands.Queries.GetBrandByNameKey;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class BrandsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BrandsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 6;

        var brands = await _mediator.Send(new GetAllBrandsQuery());

        var paginatedBrands = brands
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)brands.Count() / pageSize);

        var viewModel = new BrandsViewModel
        {
            Brands = paginatedBrands,
            CurrentPage = pageNumber,
            TotalPages = totalPages,
            PageSize = pageSize

        };
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("Brands/{nameKey}/Edit")]
    public async Task<IActionResult> Edit(string nameKey)
    {
        var dto = await _mediator.Send(new GetBrandByNameKeyQuery(nameKey));
        EditBrandCommand model = _mapper.Map<EditBrandCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("Brands/{nameKey}/Edit")]
    public async Task<IActionResult> Edit(string nameKey, EditBrandCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}