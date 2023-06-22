using AutoMapper;
using SmellIt.Application.Features.Products.Commands.EditProduct;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductMapping;
public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductDto, Product>()
            .ForMember(product => product.ProductTranslations,
                opt => opt.MapFrom<ProductTranslationsResolver>())
            .ForMember(product => product.ProductCategory,
                opt => opt.MapFrom<ProductCategoryResolver>())
            .ForMember(product => product.Brand,
                opt => opt.MapFrom<BrandResolver>())
            .ForMember(product => product.FragranceCategory,
                opt => opt.MapFrom<FragranceCategoryResolver>())
            .ForMember(product => product.Gender,
                opt => opt.MapFrom<GenderResolver>())
            .ForMember(product => product.ProductImages,
                opt => opt.MapFrom<ProductImagesResolver>())
            .ForMember(product => product.ProductPrices,
                opt => opt.MapFrom<ProductPricesResolver>());

        CreateMap<Product, ProductDto>()
            .ForMember(dto => dto.NamePl,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "pl-PL").Name))
            .ForMember(dto => dto.NameEn,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "en-GB").Name))
            .ForMember(dto => dto.DescriptionPl,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "pl-PL").Description))
            .ForMember(dto => dto.DescriptionEn,
                opt => opt.MapFrom(src => src.ProductTranslations.First(fct => fct.Language.Code == "en-GB").Description))
            .ForMember(dto => dto.ProductCategory,
                opt => opt.MapFrom(src => src.ProductCategory))
            .ForMember(dto => dto.Brand,
                opt => opt.MapFrom(src => src.Brand))
            .ForMember(dto => dto.FragranceCategory,
                opt => opt.MapFrom(src => src.FragranceCategory))
            .ForMember(dto => dto.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(dto => dto.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom<ProductPriceResolver<ProductDto>>())
            .ForMember(dest => dest.PromotionalPrice,
                opt => opt.MapFrom<ProductPromotionalPriceResolver<ProductDto>>())
            .ForMember(dest => dest.Last30DaysLowestPrice,
                opt => opt.MapFrom<ProductLast30DaysLowestPriceResolver<ProductDto>>())
            .ForMember(dest => dest.SoldAmount,
                opt => opt.MapFrom<SoldAmountResolver<ProductDto>>());

        CreateMap<ProductDto, EditProductCommand>();

        CreateMap<Product, WebsiteProductDto>()
            .ForMember(dto => dto.ProductCategory,
                opt => opt.MapFrom(src => src.ProductCategory))
            .ForMember(dto => dto.Brand,
                opt => opt.MapFrom(src => src.Brand))
            .ForMember(dto => dto.FragranceCategory,
                opt => opt.MapFrom(src => src.FragranceCategory))
            .ForMember(dto => dto.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(dto => dto.ProductImages,
                opt => opt.MapFrom(src => src.ProductImages))
            .ForMember(dest => dest.Price,
                opt => opt.MapFrom<ProductPriceResolver<WebsiteProductDto>>())
            .ForMember(dest => dest.PromotionalPrice,
                opt => opt.MapFrom<ProductPromotionalPriceResolver<WebsiteProductDto>>())
            .ForMember(dest => dest.Last30DaysLowestPrice,
                opt => opt.MapFrom<ProductLast30DaysLowestPriceResolver<WebsiteProductDto>>())
            .ForMember(dest => dest.SoldAmount,
                opt => opt.MapFrom<SoldAmountResolver<WebsiteProductDto>>())
            .ForMember(dto => dto.Name,
                opt => opt.Ignore())
            .ForMember(dto => dto.Description,
                opt => opt.Ignore())
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Name = src.ProductTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Description = src.ProductTranslations.First(fct => fct.Language.Code == languageCode).Description;
            });
    }
}