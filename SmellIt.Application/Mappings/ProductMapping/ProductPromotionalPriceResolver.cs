using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Application.Features.ProductPrices.DTOs;

namespace SmellIt.Application.Mappings.ProductMapping;

public class ProductPromotionalPriceResolver<T> : IValueResolver<Product, T, ProductPriceDto?>
{
    public ProductPriceDto? Resolve(Product source, T destination, ProductPriceDto? destMember, ResolutionContext context)
    {
        var productPrice = source.ProductPrices
            .Where(pp =>
                pp.IsActive && pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                pp.StartDateTime <= DateTime.Now).MaxBy(pp => pp.StartDateTime);
        if(productPrice == null) return null;
        return new ProductPriceDto
        {
            Value = productPrice.Value, 
            StartDateTime = productPrice.StartDateTime,
            EndDateTime = productPrice.EndDateTime
        };
    }
}