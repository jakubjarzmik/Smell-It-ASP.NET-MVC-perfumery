using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.WebsiteTexts;

namespace SmellIt.Application.Mappings.WebsiteTextMapping;
public class WebsiteTextTranslationsResolver : IValueResolver<WebsiteTextDto, WebsiteText, List<WebsiteTextTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public WebsiteTextTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public List<WebsiteTextTranslation> Resolve(WebsiteTextDto source, WebsiteText destination, List<WebsiteTextTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<WebsiteTextTranslation>
            {
                new WebsiteTextTranslation { Language = plLanguage, Text = source.TextPL },
                new WebsiteTextTranslation { Language = enLanguage, Text = source.TextEN }
            };
        }

        return new();
    }
}