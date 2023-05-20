using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.CreateFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetFragranceCategoryByEncodedName;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetPaginatedFragranceCategories;

namespace SmellIt.Admin.Controllers;
public class FragranceCategoriesController : BaseController
{
    public FragranceCategoriesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("fragrance-categories")]
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedFragranceCategoriesQuery(page, 7));
        return View(viewModel);
    }
    [Route("fragrance-categories/create")]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("fragrance-categories/create")]
    public async Task<IActionResult> Create(CreateFragranceCategoryCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("fragrance-categories/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetFragranceCategoryByEncodedNameQuery(encodedName));
        EditFragranceCategoryCommand model = Mapper.Map<EditFragranceCategoryCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("fragrance-categories/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditFragranceCategoryCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("fragrance-categories/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteFragranceCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}