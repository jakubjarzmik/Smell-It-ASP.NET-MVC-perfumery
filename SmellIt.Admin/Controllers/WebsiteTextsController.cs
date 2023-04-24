using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.CreateWebsiteText;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName;
using SmellIt.Application.SmellIt.WebsiteTexts.Commands.EditWebsiteText;
using SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetAllWebsiteTexts;
using SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class WebsiteTextsController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public WebsiteTextsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 7;

        var layoutTexts = await _mediator.Send(new GetAllWebsiteTextsQuery());

        var paginatedLayoutTexts = layoutTexts
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)layoutTexts.Count() / pageSize);

        var viewModel = new WebsiteTextsViewModel
        {
            WebsiteTexts = paginatedLayoutTexts,
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
    public async Task<IActionResult> Create(CreateWebsiteTextCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("WebsiteText/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetWebsiteTextByEncodedNameQuery(encodedName));
        EditWebsiteTextCommand model = _mapper.Map<EditWebsiteTextCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteWebsiteTextByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("WebsiteText/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditWebsiteTextCommand command)
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