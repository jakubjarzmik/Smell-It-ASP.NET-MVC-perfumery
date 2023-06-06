using AutoMapper;
using SmellIt.Application.Features.CartItems.DTOs;
using SmellIt.Application.Mappings.BrandMapping;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.CartItemMapping;
public class CartItemMappingProfile : Profile
{
    public CartItemMappingProfile()
    {
        CreateMap<CartItemDto, CartItem>()
            .ForMember(ct => ct.Product,
                opt => opt.MapFrom<ProductResolver>());
        CreateMap<CartItem, CartItemDto>()
            .ForMember(ct => ct.Product,
                opt => opt.MapFrom(src => src.Product));
    }
}