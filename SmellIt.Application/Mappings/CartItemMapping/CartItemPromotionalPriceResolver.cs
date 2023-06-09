using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Application.Features.CartItems.DTOs.Website;

namespace SmellIt.Application.Mappings.CartItemMapping;

public class CartItemPromotionalPriceResolver : IValueResolver<CartItem, CartItemDtoForView, decimal?>
{
    public decimal? Resolve(CartItem source, CartItemDtoForView destination, decimal? destMember, ResolutionContext context)
    {
        var productPrice = source.Product.ProductPrices
            .Where(pp =>
                pp.IsActive && pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime);
        return productPrice?.Value;
    }
}