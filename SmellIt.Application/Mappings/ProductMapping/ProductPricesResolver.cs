using AutoMapper;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping;

public class ProductPricesResolver : IValueResolver<ProductDto, Product, ICollection<ProductPrice>>
{
    private readonly IProductPriceRepository _productPriceRepository;

    public ProductPricesResolver(IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
    }
    public ICollection<ProductPrice> Resolve(ProductDto source, Product destination, ICollection<ProductPrice> destMember, ResolutionContext context)
    {
        return _productPriceRepository.GetByProductAsync(destination).Result;
    }
}