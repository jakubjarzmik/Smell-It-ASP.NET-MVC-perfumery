using AutoMapper;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductMapping;
public class ProductLast30DaysLowestPriceResolver<T> : IValueResolver<Product, T, decimal?>
{
    public decimal? Resolve(Product source, T destination, decimal? destMember, ResolutionContext context)
    {
        var latestPriceReduction = source.ProductPrices
            .Where(pp => pp.IsActive && pp.IsPromotion &&
                         (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                         pp.StartDateTime <= DateTime.Now)
            .OrderBy(pp=>pp.Value)
            .MaxBy(pp => pp.StartDateTime);

        if (latestPriceReduction == null) return null;
        
        return source.ProductPrices
            .Where(pp => pp.IsActive && (pp.EndDateTime == null || pp.EndDateTime > latestPriceReduction.StartDateTime.AddDays(-30)) && pp.StartDateTime <= latestPriceReduction.StartDateTime && pp != latestPriceReduction)
            .MinBy(pp => pp.Value)?.Value;
    }
}
