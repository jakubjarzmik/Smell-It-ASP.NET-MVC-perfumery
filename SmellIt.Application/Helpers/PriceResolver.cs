using SmellIt.Domain.Entities;

namespace SmellIt.Application.Helpers;

public static class PriceResolver
{
    public static decimal GetNonPromotionalPrice(CartItem cartItem)
    {
        var productPrice = cartItem.Product.ProductPrices
            .Where(pp =>
                pp.IsActive && !pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime);
        return productPrice!.Value;
    }

    public static decimal? GetPromotionalPrice(CartItem cartItem)
    {
        var productPrice = cartItem.Product.ProductPrices
            .Where(pp =>
                pp.IsActive && pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime);
        return productPrice?.Value;
    }
    public static decimal GetActualPrice(CartItem cartItem)
    {
        return GetPromotionalPrice(cartItem) ?? GetNonPromotionalPrice(cartItem);
    }
}