using AutoMapper;
using SmellIt.Application.SmellIt.Products;
using SmellIt.Application.SmellIt.Products.Commands.EditProduct;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductMapping;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductDto, Product>()
            .ForMember(brand => brand.ProductTranslations,
                opt => opt.MapFrom<ProductTranslationsResolver>())
            .ForMember(brand => brand.ProductCategory,
                opt => opt.MapFrom<ProductCategoryResolver>())
            .ForMember(brand => brand.Brand,
                opt => opt.MapFrom<BrandResolver>())
            .ForMember(brand => brand.FragranceCategory,
                opt => opt.MapFrom<FragranceCategoryResolver>())
            .ForMember(brand => brand.Gender,
                opt => opt.MapFrom<GenderResolver>())
            .ForMember(brand => brand.ProductImages,
                opt => opt.MapFrom<ProductImagesResolver>());

        CreateMap<Product, ProductDto>()
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "en-GB").Description))
            .ForMember(brand => brand.ProductCategory,
                opt => opt.MapFrom(src => src.ProductCategory))
            .ForMember(brand => brand.Brand,
                opt => opt.MapFrom(src => src.Brand))
            .ForMember(brand => brand.FragranceCategory,
                opt => opt.MapFrom(src => src.FragranceCategory))
            .ForMember(brand => brand.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(brand => brand.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages));

        CreateMap<ProductDto, EditProductCommand>();
    }
}