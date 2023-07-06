using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.CreateBrand;
public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
{
    private readonly IUserContext _userContext;
    private readonly IBrandRepository _brandRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(IUserContext userContext, IBrandRepository brandRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _brandRepository = brandRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var brand = _mapper.Map<Brand>(request);

        if (plLanguage != null && enLanguage != null)
        {
            brand.BrandTranslations = new List<BrandTranslation>
            {
                new BrandTranslation { Language = plLanguage, Description = request.DescriptionPl },
                new BrandTranslation { Language = enLanguage, Description = request.DescriptionEn }
            };
        }
        await _brandRepository.CreateAsync(brand);

        return Unit.Value;
    }
}