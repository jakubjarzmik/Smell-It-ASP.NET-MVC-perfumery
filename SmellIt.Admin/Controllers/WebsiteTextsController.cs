using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")]int? pageNumber)
    {
        var viewModel = await Mediator.Send(new GetPaginatedWebsiteTextsQuery(pageNumber, 7));
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
    public async Task<IActionResult> Create(CreateWebsiteTextCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetWebsiteTextByEncodedNameQuery(encodedName));
        EditWebsiteTextCommand model = Mapper.Map<EditWebsiteTextCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditWebsiteTextCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteWebsiteTextByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}