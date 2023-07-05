using AutoMapper;
using SmellIt.Application.Features.CartItems.DTOs.Website;
using SmellIt.Application.Helpers;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.CartItemMapping;
public class CartItemMappingProfile : Profile
{
    public CartItemMappingProfile()
    {
        CreateMap<CartItemDtoForAdd, CartItem>();
        CreateMap<CartItem, CartItemDtoForView>()
            .ForMember(ct => ct.ProductEncodedName,
                opt => opt.MapFrom(src => src.Product.EncodedName))
            .ForMember(ct => ct.ImageUrl,
                opt => opt.MapFrom(src => src.Product.ProductImages.FirstOrDefault().ImageUrl))
            .ForMember(ct => ct.ImageAlt,
                opt => opt.MapFrom(src => src.Product.ProductImages.FirstOrDefault().ImageAlt))
            .ForMember(ct => ct.Price,
                opt => opt.MapFrom(src => PriceResolver.GetNonPromotionalPrice(src)))
            .ForMember(ct => ct.PromotionalPrice,
                opt => opt.MapFrom(src => PriceResolver.GetPromotionalPrice(src)))
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                var brand = src.Product.Brand?.Name;
                var productName = src.Product.ProductTranslations.First(fct => fct.Language.Code == languageCode).Name;
                dest.Name = brand != null ? brand + " - " : "";
                dest.Name += productName;

                var productCategory = src.Product.ProductCategory?.ProductCategoryTranslations.First(fct => fct.Language.Code == languageCode).Name;
                var gender = src.Product.Gender?.GenderTranslations.First(fct => fct.Language.Code == languageCode).Name.ToLower();
                var fragranceCategory = src.Product.FragranceCategory?.FragranceCategoryTranslations.First(fct => fct.Language.Code == languageCode).Name.ToLower();
                var capacity = src.Product.Capacity;
                dest.ProductInfo = productCategory != null ? productCategory + ", " : "";
                dest.ProductInfo += gender != null ? gender + ", " : "";
                dest.ProductInfo += fragranceCategory != null ? fragranceCategory + ", " : "";
                dest.ProductInfo += capacity != null ? capacity + " ml":"";
                dest.TotalPrice = dest.Price * dest.Quantity;
                dest.TotalPromotionalPrice = dest.PromotionalPrice * dest.Quantity;
            });
    }
}