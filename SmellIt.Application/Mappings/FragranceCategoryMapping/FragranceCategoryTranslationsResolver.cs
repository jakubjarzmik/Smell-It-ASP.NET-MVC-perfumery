using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.Features.FragranceCategories;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping;
public class FragranceCategoryTranslationsResolver : IValueResolver<FragranceCategoryDto, FragranceCategory, ICollection<FragranceCategoryTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public FragranceCategoryTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<FragranceCategoryTranslation> Resolve(FragranceCategoryDto source, FragranceCategory destination, ICollection<FragranceCategoryTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<FragranceCategoryTranslation>
            {
                new FragranceCategoryTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new FragranceCategoryTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}