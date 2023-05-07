using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.SmellIt.Products;

namespace SmellIt.Application.Mappings.ProductMapping;
public class ProductTranslationsResolver : IValueResolver<ProductDto, Product, ICollection<ProductTranslation>>
{
    private readonly ILanguageRepository _languageRepository;

    public ProductTranslationsResolver(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public ICollection<ProductTranslation> Resolve(ProductDto source, Product destination, ICollection<ProductTranslation> destMember, ResolutionContext context)
    {
        var plLanguage = _languageRepository.GetByCode("pl-PL").Result;
        var enLanguage = _languageRepository.GetByCode("en-GB").Result;

        if (plLanguage != null && enLanguage != null)
        {
            return new List<ProductTranslation>
            {
                new ProductTranslation { Language = plLanguage, Name = source.NamePl, Description = source.DescriptionPl },
                new ProductTranslation { Language = enLanguage, Name = source.NameEn, Description = source.DescriptionEn }
            };
        }

        return default!;
    }
}