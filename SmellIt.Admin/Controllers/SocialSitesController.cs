using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.SmellIt.SocialSites.Commands.CreateSocialSite;
using SmellIt.Application.SmellIt.SocialSites.Commands.DeleteSocialSiteByEncodedName;
using SmellIt.Application.SmellIt.SocialSites.Commands.EditSocialSite;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetPaginatedSocialSites;
using SmellIt.Application.SmellIt.SocialSites.Queries.GetSocialSiteByEncodedName;

namespace SmellIt.Admin.Controllers;
public class SocialSitesController : BaseController
{
    protected readonly List<string> socialTypes = new() { "dropbox", "facebook", "github", "instagram", "linkedin", "pinterest", "twitter", "youtube" };

    public SocialSitesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("social-sites")]
    public async Task<IActionResult> Index(int? page)
    {
        var viewModel = await Mediator.Send(new GetPaginatedSocialSitesQuery(page, 7));
        return View(viewModel);
    }

    [Route("social-sites/create")]
    public IActionResult Create()
    {
        ViewData["SocialTypes"] = socialTypes;
        return View();
    }

    [HttpPost]
    [Route("social-sites/create")]
    public async Task<IActionResult> Create(CreateSocialSiteCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("social-sites/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        ViewData["SocialTypes"] = socialTypes;
        var dto = await Mediator.Send(new GetSocialSiteByEncodedNameQuery(encodedName));
        EditSocialSiteCommand model = Mapper.Map<EditSocialSiteCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("social-sites/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditSocialSiteCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("social-sites/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteSocialSiteByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}