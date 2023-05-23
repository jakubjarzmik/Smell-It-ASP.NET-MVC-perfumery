using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.Features.WebsiteTexts;

namespace SmellIt.Application.Mappings.WebsiteTextMapping;
public class WebsiteTextTranslationsResolver : IValueResolver<WebsiteTextForAdminDto, WebsiteText, ICollection<WebsiteTextTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public WebsiteTextTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<WebsiteTextTranslation> Resolve(WebsiteTextForAdminDto source, WebsiteText destination, ICollection<WebsiteTextTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result!;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result!;


        return new List<WebsiteTextTranslation>
        {
            new WebsiteTextTranslation { Language = plLanguage, Text = source.TextPl, WebsiteText = destination },
            new WebsiteTextTranslation { Language = enLanguage, Text = source.TextEn, WebsiteText = destination }
        };

    }
}