using AutoMapper;
using MediatR;
using SmellIt.Application.Features.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.Features.HomeBanners.Commands.DeleteHomeBannerByEncodedName;
using SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.Features.HomeBanners.Queries.GetHomeBannerByEncodedName;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.HomeBanners.Queries.GetPaginatedHomeBanners;
using Microsoft.AspNetCore.Authorization;

namespace SmellIt.Admin.Controllers;

[Authorize(Roles = "Admin,Employee")]
[Route("home-banners")]
public class HomeBannersController : BaseController
{
    public HomeBannersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        return View(await Mediator.Send(new GetPaginatedHomeBannersQuery(pageNumber, 7)));
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
    public async Task<IActionResult> Create(CreateHomeBannerCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetHomeBannerByEncodedNameQuery(encodedName));
        EditHomeBannerCommand model = Mapper.Map<EditHomeBannerCommand>(dto);
        return View(model);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditHomeBannerCommand command)
    {
        return await HandleCommand(command, nameof(Index), View);
    }

    [Authorize(Roles = "Admin")]
    [Route("{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteHomeBannerByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}