using AutoMapper;
using MediatR;
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
    
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedFragranceCategoriesQuery(page, 7));
        return View(viewModel);
    }
    [Route("create")]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateFragranceCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetFragranceCategoryByEncodedNameQuery(encodedName));
        EditFragranceCategoryCommand model = Mapper.Map<EditFragranceCategoryCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditFragranceCategoryCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteFragranceCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}