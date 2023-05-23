using AutoMapper;
using SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory;
using SmellIt.Application.Features.ProductCategories.DTOs;
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
            .ForMember(dto => dto.ParentCategory,
                opt => opt.MapFrom(src => src.ParentCategory))
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB").Description));

        CreateMap<ProductCategoryDto, EditProductCategoryCommand>();

        CreateMap<ProductCategory, WebsiteProductCategoryDto>()
            .ForMember(dto => dto.ParentCategory,
                opt => opt.MapFrom(src => src.ParentCategory))
            .ForMember(dto => dto.Name,
                opt => opt.Ignore())
            .ForMember(dto => dto.Description,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.ProductCategoryTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Description = src.ProductCategoryTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}