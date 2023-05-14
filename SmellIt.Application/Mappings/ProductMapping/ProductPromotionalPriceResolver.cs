using AutoMapper;
using SmellIt.Application.SmellIt.Products;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmellIt.Application.SmellIt.ProductPrices;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class ProductPromotionalPriceResolver : IValueResolver<Product, ProductDto, ProductPriceDto?>
    {
        public ProductPriceDto? Resolve(Product source, ProductDto destination, ProductPriceDto? destMember, ResolutionContext context)
        {
            var productPrice = source.ProductPrices
                .Where(pp =>
                    pp.IsActive && pp.IsPromotion && (pp.EndDateTime == null || pp.EndDateTime > DateTime.UtcNow) &&
                    pp.StartDateTime <= DateTime.UtcNow).OrderByDescending(pp => pp.StartDateTime).FirstOrDefault();
            if(productPrice == null) return null;
            return new ProductPriceDto
            {
                Value = productPrice.Value, 
                StartDateTime = productPrice.StartDateTime,
                EndDateTime = productPrice.EndDateTime
            };
        }
    }
}
