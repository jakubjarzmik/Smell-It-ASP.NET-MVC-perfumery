using AutoMapper;
using SmellIt.Application.SmellIt.ProductCategories;
using SmellIt.Application.SmellIt.ProductCategories.Commands.EditProductCategory;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductCategoryMapping;
public class ProductCategoryMappingProfile : Profile
{
    public ProductCategoryMappingProfile()
    {
        CreateMap<ProductCategoryDto, ProductCategory>()
            .ForMember(brand => brand.ProductCategoryTranslations,
                opt => opt.MapFrom<ProductCategoryTranslationsResolver>())
            .ForMember(brand => brand.ParentCategory,
                opt => opt.MapFrom<ParentCategoryResolver>());

        CreateMap<ProductCategory, ProductCategoryDto>()
            .ForMember(dto => dto.ParentCategoryEncodedName,
                opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.EncodedName : null))
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Description));

        CreateMap<ProductCategoryDto, EditProductCategoryCommand>();
    }
}