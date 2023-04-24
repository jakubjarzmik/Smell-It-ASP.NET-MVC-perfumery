using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetHomeBannerByEncodedName;
using SmellIt.Application.ViewModels;

namespace SmellIt.Admin.Controllers;
public class HomeBannersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeBannersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    public async Task<IActionResult> Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 7;

        var homeBanners = await _mediator.Send(new GetAllHomeBannersQuery());

        var paginatedHomeBanners = homeBanners
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        int totalPages = (int)Math.Ceiling((double)homeBanners.Count() / pageSize);

        var viewModel = new HomeBannersViewModel
		{
            HomeBanners = paginatedHomeBanners,
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
    public async Task<IActionResult> Create(CreateHomeBannerCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

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