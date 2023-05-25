using AutoMapper;
using SmellIt.Application.Features.Genders.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

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
        var plLanguage = _languageRepository.GetByCodeAsync("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCodeAsync("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<GenderTranslation>
            {
                new GenderTranslation { Language = plLanguage, Name = source.NamePl },
                new GenderTranslation { Language = enLanguage, Name = source.NameEn }
            };
        }

        return default!;
    }
}