using AutoMapper;
using SmellIt.Application.SmellIt.Products;
using SmellIt.Domain.Entities;
using SmellIt.Application.SmellIt.ProductPrices;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class ProductPriceResolver : IValueResolver<Product, ProductDto, ProductPriceDto>
    {
        public ProductPriceDto Resolve(Product source, ProductDto destination, ProductPriceDto destMember, ResolutionContext context)
        {
            var productPrice = source.ProductPrices
                .Where(pp =>
                    pp.IsActive && !pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.UtcNow) &&
                    pp.StartDateTime <= DateTime.UtcNow).OrderByDescending(pp => pp.StartDateTime).First();
            return new ProductPriceDto
            {
                Value = productPrice.Value, 
                StartDateTime = productPrice.StartDateTime,
                EndDateTime = productPrice.EndDateTime
            };
        }
    }
}
