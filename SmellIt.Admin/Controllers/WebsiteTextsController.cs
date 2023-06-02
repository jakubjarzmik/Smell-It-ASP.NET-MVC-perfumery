using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.WebsiteTexts.Commands.CreateWebsiteText;
using SmellIt.Application.Features.WebsiteTexts.Commands.DeleteWebsiteTextByEncodedName;
using SmellIt.Application.Features.WebsiteTexts.Commands.EditWebsiteText;
using SmellIt.Application.Features.WebsiteTexts.Queries.GetPaginatedWebsiteTexts;
using SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByEncodedName;

namespace SmellIt.Admin.Controllers;

[Route("website-texts")]
public class WebsiteTextsController : BaseController
{
    public WebsiteTextsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedWebsiteTextsQuery(page, 7));
        return View(viewModel);
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateWebsiteTextCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetWebsiteTextByEncodedNameQuery(encodedName));
        EditWebsiteTextCommand model = Mapper.Map<EditWebsiteTextCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditWebsiteTextCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteWebsiteTextByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}