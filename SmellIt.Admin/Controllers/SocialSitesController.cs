using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.SocialSites.Commands.CreateSocialSite;
using SmellIt.Application.Features.SocialSites.Commands.DeleteSocialSiteByEncodedName;
using SmellIt.Application.Features.SocialSites.Commands.EditSocialSite;
using SmellIt.Application.Features.SocialSites.Queries.GetPaginatedSocialSites;
using SmellIt.Application.Features.SocialSites.Queries.GetSocialSiteByEncodedName;
using System.Data;

namespace SmellIt.Admin.Controllers;

[Route("social-sites")]
public class SocialSitesController : BaseController
{
    protected readonly List<string> socialTypes = new() { "dropbox", "facebook", "github", "instagram", "linkedin", "pinterest", "twitter", "youtube" };

    public SocialSitesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        var viewModel = await Mediator.Send(new GetPaginatedSocialSitesQuery(pageNumber, 7));
        return View(viewModel);
    }

    [Authorize(Roles = "Admin")]
    [Route("create")]
    public IActionResult Create()
    {
        ViewBag.SocialTypes = socialTypes;
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateSocialSiteCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetSocialSiteByEncodedNameQuery(encodedName));
        EditSocialSiteCommand model = Mapper.Map<EditSocialSiteCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditSocialSiteCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteSocialSiteByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}