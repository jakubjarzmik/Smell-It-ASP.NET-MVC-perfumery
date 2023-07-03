using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.CreateBrand;
public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
{
    private readonly IBrandRepository _brandRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;

    public CreateBrandCommandHandler(IBrandRepository brandRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
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