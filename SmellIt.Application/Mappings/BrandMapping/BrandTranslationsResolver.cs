using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.Brands;

namespace SmellIt.Application.Mappings.BrandMapping;
public class BrandTranslationsResolver : IValueResolver<BrandDto, Brand, List<BrandTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public BrandTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public List<BrandTranslation> Resolve(BrandDto source, Brand destination, List<BrandTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<BrandTranslation>
            {
                new BrandTranslation { Language = plLanguage, LanguageId = plLanguage.Id, Description = source.DescriptionPl, Brand = destination, BrandId = destination.Id},
                new BrandTranslation { Language = enLanguage, LanguageId = enLanguage.Id, Description = source.DescriptionEn, Brand = destination, BrandId = destination.Id }
            };
        }

        return new();
    }
}