using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.Brands;

namespace SmellIt.Application.Mappings.BrandMapping;
public class BrandTranslationsResolver : IValueResolver<BrandDto, Brand, ICollection<BrandTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public BrandTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<BrandTranslation> Resolve(BrandDto source, Brand destination, ICollection<BrandTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<BrandTranslation>
            {
                new BrandTranslation { Language = plLanguage, Description = source.DescriptionPl, Brand = destination },
                new BrandTranslation { Language = enLanguage, Description = source.DescriptionEn, Brand = destination }
            };
        }

        return default!;
    }
}