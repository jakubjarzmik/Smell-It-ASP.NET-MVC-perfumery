using AutoMapper;
using SmellIt.Application.Features.CartItems.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.CartItemMapping;

public class ProductResolver : IValueResolver<CartItemDto, CartItem, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductResolver(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product Resolve(CartItemDto source, CartItem destination, Product destMember, ResolutionContext context)
    {
        return _productRepository.GetByEncodedNameAsync(source.ProductEncodedName).Result!;
    }
}