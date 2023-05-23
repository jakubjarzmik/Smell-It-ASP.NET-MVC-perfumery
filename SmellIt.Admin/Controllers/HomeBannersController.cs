using AutoMapper;
using MediatR;
using SmellIt.Application.Features.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.Features.HomeBanners.Commands.DeleteHomeBannerByEncodedName;
using SmellIt.Application.Features.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.Features.HomeBanners.Queries.GetHomeBannerByEncodedName;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.HomeBanners.Queries.GetPaginatedHomeBanners;

namespace SmellIt.Admin.Controllers;
public class HomeBannersController : BaseController
{

    public HomeBannersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    [Route("home-banners")]
    public async Task<IActionResult> Index(int? page)
    {
        return View(await Mediator.Send(new GetPaginatedHomeBannersQuery(page, 7)));
    }
    [Route("home-banners/create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Route("home-banners/create")]
    public async Task<IActionResult> Create(CreateHomeBannerCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }


    [Route("home-banners/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await Mediator.Send(new GetHomeBannerByEncodedNameQuery(encodedName));
        EditHomeBannerCommand model = Mapper.Map<EditHomeBannerCommand>(dto);
        return View(model);
    }

    [HttpPost]
    [Route("home-banners/{encodedName}/edit")]
    public async Task<IActionResult> Edit(string encodedName, EditHomeBannerCommand command)
    {
        command.EncodedName = encodedName;
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await Mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Route("home-banners/{encodedName}/delete")]
    public async Task<IActionResult> Delete(string encodedName)
    {
        await Mediator.Send(new DeleteHomeBannerByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}