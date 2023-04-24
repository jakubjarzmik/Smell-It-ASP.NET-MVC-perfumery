using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.HomeBanners;

namespace SmellIt.Application.Mappings.HomeBannerMapping;
public class HomeBannerTranslationsResolver : IValueResolver<HomeBannerDto, HomeBanner, List<HomeBannerTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public HomeBannerTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public List<HomeBannerTranslation> Resolve(HomeBannerDto source, HomeBanner destination, List<HomeBannerTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<HomeBannerTranslation>
            {
                new HomeBannerTranslation { Language = plLanguage, Text = source.TextPL },
                new HomeBannerTranslation { Language = enLanguage, Text = source.TextEN }
            };
        }

        return new();
    }
}