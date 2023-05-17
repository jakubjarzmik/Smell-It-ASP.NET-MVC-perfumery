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
                opt => opt.MapFrom<ProductPriceResolver>())
            .ForMember(dest => dest.PromotionalPrice,
                opt => opt.MapFrom<ProductPromotionalPriceResolver>())
            .ForMember(dest => dest.Last30DaysLowestPrice,
                opt => opt.MapFrom(src => src.ProductPrices
                    .Where(pp => pp.IsActive && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now.AddDays(-30)) && pp.StartDateTime <= DateTime.Now)
                    .OrderBy(pp => pp.Value)
                    .FirstOrDefault().Value));
        //.ForMember(dto => dto.Price,
        //    opt => opt.MapFrom(src => src.ProductPrices.Where(pp=>pp.IsActive && !pp.IsPromotion && (pp.DeletedAt == null || pp.DeletedAt > DateTime.Now))
        //        .OrderByDescending(pp=>pp.CreatedAt).First().Value))
        //.ForMember(dto => dto.PromotionalPrice,
        //    opt => opt.MapFrom(src => src.ProductPrices.Where(pp=>pp.IsActive && pp.IsPromotion && (pp.DeletedAt == null || pp.DeletedAt > DateTime.Now))
        //        .OrderByDescending(pp => pp.CreatedAt).FirstOrDefault().Value))
        //.ForMember(dto => dto.Last30DaysLowestPrice,
        //    opt => opt.MapFrom(src => src.ProductPrices.Where(pp=>pp.DeletedAt >= DateTime.Now.AddDays(-30) || pp.DeletedAt == null)
        //        .OrderBy(pp=>pp.Value).FirstOrDefault().Value));

        CreateMap<ProductDto, EditProductCommand>();
    }
}