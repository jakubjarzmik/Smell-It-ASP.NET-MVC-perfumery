using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Brands.Commands.CreateBrand;
using SmellIt.Application.Features.Brands.Commands.DeleteBrandByEncodedName;
using SmellIt.Application.Features.Brands.Commands.EditBrand;
using SmellIt.Application.Features.Brands.Queries.GetBrandByEncodedName;
using SmellIt.Application.Features.Brands.Queries.GetPaginatedBrands;

namespace SmellIt.Admin.Controllers;

[Authorize(Roles = "Admin,Employee")]
[Route("brands")]
public class BrandsController : BaseController
{
    public BrandsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        var viewModel = await Mediator.Send(new GetPaginatedBrandsQuery(pageNumber, 7));
        return View(viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetBrandByEncodedNameQuery(encodedName));
        EditBrandCommand model = Mapper.Map<EditBrandCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditBrandCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteBrandByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}