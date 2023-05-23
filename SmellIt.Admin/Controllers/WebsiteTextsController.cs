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
public class WebsiteTextsController : BaseController
{
    public WebsiteTextsController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("website-texts")]
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedWebsiteTextsQuery(page, 7));
        return View(viewModel);
    }

    [Route("website-texts/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("website-texts/create")]
    public async Task<IActionResult> Create(CreateWebsiteTextCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("website-texts/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetWebsiteTextByEncodedNameQuery(encodedName));
        EditWebsiteTextCommand model = Mapper.Map<EditWebsiteTextCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("website-texts/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditWebsiteTextCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("website-texts/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteWebsiteTextByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}