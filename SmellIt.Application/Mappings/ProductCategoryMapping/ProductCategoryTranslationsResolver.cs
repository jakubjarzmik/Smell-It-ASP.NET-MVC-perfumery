using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.Features.ProductCategories.DTOs;

namespace SmellIt.Application.Mappings.ProductCategoryMapping;
public class ProductCategoryTranslationsResolver : IValueResolver<ProductCategoryDto, ProductCategory, ICollection<ProductCategoryTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public ProductCategoryTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<ProductCategoryTranslation> Resolve(ProductCategoryDto source, ProductCategory destination, ICollection<ProductCategoryTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCodeAsync("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCodeAsync("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<ProductCategoryTranslation>
            {
                new ProductCategoryTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new ProductCategoryTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}