using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.SocialSites.Commands.CreateSocialSite;
using SmellIt.Application.SmellIt.SocialSites.Commands.DeleteSocialSiteByEncodedName;
using SmellIt.Application.SmellIt.SocialSites.Commands.EditSocialSite;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetPaginatedSocialSites;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetSocialSiteByEncodedName;

namespace SmellIt.Admin.Controllers;
public class SocialSitesController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    protected readonly List<string> socialTypes = new() { "dropbox", "facebook", "github", "instagram", "linkedin", "pinterest", "twitter", "youtube" };

    public SocialSitesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await _mediator.Send(new GetPaginatedSocialSitesQuery(page, 7));
        return View(viewModel);
    }

    public IActionResult Create()
    {
        ViewData["SocialTypes"] = socialTypes;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSocialSiteCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("SocialSites/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        ViewData["SocialTypes"] = socialTypes;
        var dto = await _mediator.Send(new GetSocialSiteByEncodedNameQuery(encodedName));
        EditSocialSiteCommand model = _mapper.Map<EditSocialSiteCommand>(dto);
        return View(model);
    }
    
    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteSocialSiteByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("SocialSites/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditSocialSiteCommand command)
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