using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.DeleteBrandByEncodedName;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.Brands.Queries.GetBrandByEncodedName;
using SmellIt.Application.SmellIt.Brands.Queries.GetPaginatedBrands;

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
        var viewModel = await _mediator.Send(new GetPaginatedBrandsQuery(page, 7));
        return View(viewModel);
    }

    public IActionResult Create()
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

    [Route("Brands/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetBrandByEncodedNameQuery(encodedName));
        EditBrandCommand model = _mapper.Map<EditBrandCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteBrandByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("Brands/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditBrandCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}