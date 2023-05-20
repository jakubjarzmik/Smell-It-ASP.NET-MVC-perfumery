using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.SmellIt.Brands.Commands.CreateBrand;
using SmellIt.Application.SmellIt.Brands.Commands.DeleteBrandByEncodedName;
using SmellIt.Application.SmellIt.Brands.Commands.EditBrand;
using SmellIt.Application.SmellIt.Brands.Queries.GetBrandByEncodedName;
using SmellIt.Application.SmellIt.Brands.Queries.GetPaginatedBrands;

namespace SmellIt.Admin.Controllers;
public class BrandsController : BaseController
{
    public BrandsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("brands")]
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedBrandsQuery(page, 7));
        return View(viewModel);
    }
    [Route("brands/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("brands/create")]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("brands/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetBrandByEncodedNameQuery(encodedName));
        EditBrandCommand model = Mapper.Map<EditBrandCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("brands/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditBrandCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("brands/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteBrandByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}