using AutoMapper;
using SmellIt.Application.Features.OrderItems.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.OrderItemMapping;
public class OrderItemMappingProfile : Profile
{
    public OrderItemMappingProfile()
    {
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dto => dto.ProductImage,
                opt => opt.MapFrom(src => src.Product.ProductImages.FirstOrDefault().ImageUrl))
            .AfterMap((src, dest, ctx) =>
            {
                var languageCode = ctx.Items["LanguageCode"].ToString();
                dest.Product = src.Product.ProductTranslations.First(fct => fct.Language.Code == languageCode).Name;
            });
    }
}