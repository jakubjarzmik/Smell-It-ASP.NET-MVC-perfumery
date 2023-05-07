using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.FragranceCategories;

namespace SmellIt.Application.Mappings.GenderMapping;
public class GenderTranslationsResolver : IValueResolver<GenderDto, Gender, ICollection<GenderTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public GenderTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<GenderTranslation> Resolve(GenderDto source, Gender destination, ICollection<GenderTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<GenderTranslation>
            {
                new GenderTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new GenderTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}