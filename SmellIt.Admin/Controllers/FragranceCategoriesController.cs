using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.FragranceCategories.Commands.CreateFragranceCategory;
using SmellIt.Application.Features.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName;
using SmellIt.Application.Features.FragranceCategories.Commands.EditFragranceCategory;
using SmellIt.Application.Features.FragranceCategories.Queries.GetFragranceCategoryByEncodedName;
using SmellIt.Application.Features.FragranceCategories.Queries.GetPaginatedFragranceCategories;

namespace SmellIt.Admin.Controllers;
[Route("fragrance-categories")]
public class FragranceCategoriesController : BaseController
{
    public FragranceCategoriesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        var viewModel = await Mediator.Send(new GetPaginatedFragranceCategoriesQuery(pageNumber, 7));
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
    public async Task<IActionResult> Create(CreateFragranceCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetFragranceCategoryByEncodedNameQuery(encodedName));
        EditFragranceCategoryCommand model = Mapper.Map<EditFragranceCategoryCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditFragranceCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteFragranceCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}