using AutoMapper;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping;

public class BrandResolver : IValueResolver<ProductDto, Product, Brand?>
{
    private readonly IBrandRepository _brandRepository;

    public BrandResolver(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public Brand? Resolve(ProductDto source, Product destination, Brand? destMember, ResolutionContext context)
    {
        if (source.Brand == null) return null;
        return _brandRepository.GetByEncodedNameAsync(source.Brand.EncodedName).Result;
    }
}