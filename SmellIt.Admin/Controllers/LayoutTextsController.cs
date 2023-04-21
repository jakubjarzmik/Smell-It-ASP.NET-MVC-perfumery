using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.LayoutTexts.Commands.CreateLayoutText;
using SmellIt.Application.SmellIt.LayoutTexts.Commands.DeleteLayoutTextByEncodedName;
using SmellIt.Application.SmellIt.LayoutTexts.Commands.EditLayoutText;
using SmellIt.Application.SmellIt.LayoutTexts.Queries.GetAllLayoutTexts;
using SmellIt.Application.SmellIt.LayoutTexts.Queries.GetLayoutTextByEncodedName;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class LayoutTextsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LayoutTextsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 7;

        var layoutTexts = await _mediator.Send(new GetAllLayoutTextsQuery());

        var paginatedLayoutTexts = layoutTexts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)layoutTexts.Count() / pageSize);

        var viewModel = new LayoutTextsViewModel
        {
            LayoutTexts = paginatedLayoutTexts,
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
    public async Task<IActionResult> Create(CreateLayoutTextCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("LayoutTexts/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetLayoutTextByEncodedNameQuery(encodedName));
        EditLayoutTextCommand model = _mapper.Map<EditLayoutTextCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteLayoutTextByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("LayoutTexts/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditLayoutTextCommand command)
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