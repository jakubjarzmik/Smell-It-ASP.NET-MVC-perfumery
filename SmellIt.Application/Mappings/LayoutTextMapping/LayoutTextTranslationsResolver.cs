using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.LayoutTexts;

namespace SmellIt.Application.Mappings.LayoutTextMapping;
public class LayoutTextTranslationsResolver : IValueResolver<LayoutTextDto, LayoutText, List<LayoutTextTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public LayoutTextTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public List<LayoutTextTranslation> Resolve(LayoutTextDto source, LayoutText destination, List<LayoutTextTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<LayoutTextTranslation>
            {
                new LayoutTextTranslation { LanguageId = plLanguage.Id, Text = source.TextPL },
                new LayoutTextTranslation { LanguageId = enLanguage.Id, Text = source.TextEN }
            };
        }

        return new();
    }
}