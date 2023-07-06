using AutoMapper;
using MediatR;
using SmellIt.Application.Helpers.Images;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.HomeBanners.Commands.CreateHomeBanner;

public class CreateHomeBannerCommandHandler : IRequestHandler<CreateHomeBannerCommand>
{
    private readonly IUserContext _userContext;
    private readonly IHomeBannerRepository _homeBannerRepository;
    private readonly IMapper _mapper;
    private readonly ILanguageRepository _languageRepository;
    private readonly IImageUploader _imageUploader;
    public CreateHomeBannerCommandHandler(IUserContext userContext, IHomeBannerRepository homeBannerRepository, IMapper mapper, ILanguageRepository languageRepository, IImageUploader imageUploader)
    {
        _userContext = userContext;
        _homeBannerRepository = homeBannerRepository;
        _mapper = mapper;
        _languageRepository = languageRepository;
        _imageUploader = imageUploader;
    }

    public async Task<Unit> Handle(CreateHomeBannerCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var homeBanner = _mapper.Map<HomeBanner>(request);

        if (plLanguage != null && enLanguage != null)
        {
            homeBanner.HomeBannerTranslations = new List<HomeBannerTranslation>
            {
                new HomeBannerTranslation { Language = plLanguage, Text = request.TextPl },
                new HomeBannerTranslation { Language = enLanguage, Text = request.TextEn }
            };
        }

        if (request.ImageFile != null)
        {
            string imagePath = await _imageUploader.UploadImageAsync("HomeBanners", request.ImageFile, homeBanner.Key);
            homeBanner.ImagePath = imagePath;
        }

        await _homeBannerRepository.CreateAsync(homeBanner);

        return Unit.Value;
    }
}