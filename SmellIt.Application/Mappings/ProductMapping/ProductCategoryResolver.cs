using AutoMapper;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping;

public class ProductCategoryResolver : IValueResolver<ProductDto, Product, ProductCategory?>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryResolver(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public ProductCategory? Resolve(ProductDto source, Product destination, ProductCategory? destMember, ResolutionContext context)
    {
        if (source.ProductCategory == null) return null;
        return _productCategoryRepository.GetByEncodedNameAsync(source.ProductCategory.EncodedName).Result;
    }
}