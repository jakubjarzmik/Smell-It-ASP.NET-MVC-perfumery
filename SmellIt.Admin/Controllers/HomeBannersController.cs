using AutoMapper;
using MediatR;
using SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetHomeBannerByEncodedName;
using SmellIt.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Helpers;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetPaginatedHomeBanners;

namespace SmellIt.Admin.Controllers;
public class HomeBannersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public HomeBannersController(IMediator mediator, IMapper mapper, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _mapper = mapper;
        _env = env;
    }

    public async Task<IActionResult> Index(int? page)
    {
        BannerImageManager.DeleteNonExistentBanners(await _mediator.Send(new GetAllHomeBannersQuery()), _env);

        return View(await _mediator.Send(new GetPaginatedHomeBannersQuery(page,7)));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHomeBannerCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        if (command.ImageFile != null)
            await BannerImageManager.AddBannerImageAsync(command.ImageFile);

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }


    [Route("HomeBanner/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName)
    {
        var dto = await _mediator.Send(new GetHomeBannerByEncodedNameQuery(encodedName));
        EditHomeBannerCommand model = _mapper.Map<EditHomeBannerCommand>(dto);
        return View(model);
    }

    public async Task<IActionResult> Delete(string encodedName)
    {
        await _mediator.Send(new DeleteHomeBannerByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Route("HomeBanner/{encodedName}/Edit")]
    public async Task<IActionResult> Edit(string encodedName, EditHomeBannerCommand command)
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