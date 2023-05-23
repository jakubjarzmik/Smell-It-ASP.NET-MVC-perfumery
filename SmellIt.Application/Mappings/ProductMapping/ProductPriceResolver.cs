using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Application.Features.ProductPrices;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class ProductPriceResolver<T> : IValueResolver<Product, T, ProductPriceDto>
    {
        public ProductPriceDto Resolve(Product source, T destination, ProductPriceDto destMember, ResolutionContext context)
        {
            var productPrice = source.ProductPrices
                .Where(pp =>
                    pp.IsActive && !pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.Now) &&
                    pp.StartDateTime <= DateTime.Now).OrderByDescending(pp => pp.StartDateTime).First();
            return new ProductPriceDto
            {
                Value = productPrice.Value, 
                StartDateTime = productPrice.StartDateTime,
                EndDateTime = productPrice.EndDateTime
            };
        }
    }
}
