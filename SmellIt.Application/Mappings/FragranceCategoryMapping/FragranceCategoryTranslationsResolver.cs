using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Application.SmellIt.FragranceCategories;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping;
public class FragranceCategoryTranslationsResolver : IValueResolver<FragranceCategoryDto, FragranceCategory, List<FragranceCategoryTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public FragranceCategoryTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public List<FragranceCategoryTranslation> Resolve(FragranceCategoryDto source, FragranceCategory destination, List<FragranceCategoryTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<FragranceCategoryTranslation>
            {
                new FragranceCategoryTranslation { Language = plLanguage, Name = source.NamePL, Description = source.DescriptionPL },
                new FragranceCategoryTranslation { Language = enLanguage, Name = source.NameEN, Description = source.DescriptionEN }
            };
        }

        return new();
    }
}