using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Brands.Commands.CreateBrand;
using SmellIt.Application.Features.Brands.Commands.DeleteBrandByEncodedName;
using SmellIt.Application.Features.Brands.Commands.EditBrand;
using SmellIt.Application.Features.Brands.Queries.GetBrandByEncodedName;
using SmellIt.Application.Features.Brands.Queries.GetPaginatedBrands;

namespace SmellIt.Admin.Controllers;
[Route("brands")]
public class BrandsController : BaseController
{
    public BrandsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedBrandsQuery(page, 7));
        return View(viewModel);
    }
    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetBrandByEncodedNameQuery(encodedName));
        EditBrandCommand model = Mapper.Map<EditBrandCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditBrandCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteBrandByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}