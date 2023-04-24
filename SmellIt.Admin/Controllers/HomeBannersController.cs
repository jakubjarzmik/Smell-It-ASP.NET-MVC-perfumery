using AutoMapper;
using MediatR;
using SmellIt.Application.SmellIt.HomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Commands.CreateHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Commands.DeleteHomeBannerByEncodedName;
using SmellIt.Application.SmellIt.HomeBanners.Commands.EditHomeBanner;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetAllHomeBanners;
using SmellIt.Application.SmellIt.HomeBanners.Queries.GetHomeBannerByEncodedName;
using SmellIt.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

    private void CheckBannersExist(IEnumerable<HomeBannerDto> banners)
    {
        var bannerKeys = banners.Select(b => b.Key);

        var imagesFolderPath = Path.Combine(_env.WebRootPath, "images/banners");

        var filesInFolder = Directory.GetFiles(imagesFolderPath);

        foreach (var filePath in filesInFolder)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            if (!bannerKeys.Contains(fileName))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }

    private static async Task AddFileAsync(IFormFile file)
    {
        var fileName = file.FileName;
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "banners");
        var filePath = Path.Combine(folderPath, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);
    }

    public async Task<IActionResult> Index(int? page)
    {
        var pageNumber = page ?? 1;
        var pageSize = 7;

        var homeBanners = await _mediator.Send(new GetAllHomeBannersQuery());

        CheckBannersExist(homeBanners);

        var paginatedHomeBanners = homeBanners
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)homeBanners.Count() / pageSize);

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

        if (command.ImageFile != null)
            await AddFileAsync(command.ImageFile);

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