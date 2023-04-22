using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.CreateFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName;
using SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetAllFragranceCategories;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetFragranceCategoryByEncodedName;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class FragranceCategoriesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public FragranceCategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 7;

        var fragranceCategories = await _mediator.Send(new GetAllFragranceCategoriesQuery());

        var paginatedFragranceCategories = fragranceCategories
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)fragranceCategories.Count() / pageSize);

        var viewModel = new FragranceCategoriesViewModel
        {
            FragranceCategories = paginatedFragranceCategories,
            CurrentPage = pageNumber,
            TotalPages = totalPages,
            PageSize = pageSize
        };
        return View(viewModel);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFragranceCategoryCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("FragranceCategories/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetFragranceCategoryByEncodedNameQuery(encodedName));
        EditFragranceCategoryCommand model = _mapper.Map<EditFragranceCategoryCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteFragranceCategoryByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("FragranceCategories/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditFragranceCategoryCommand command)
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