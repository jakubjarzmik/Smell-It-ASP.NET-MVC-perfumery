using AutoMapper;
using SmellIt.Application.Features.CartItems.DTOs.Website;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.CartItemMapping;

public class CartItemProductResolver : IValueResolver<CartItemDtoForAdd, CartItem, Product>
{
    private readonly IProductRepository _productRepository;

    public CartItemProductResolver(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product Resolve(CartItemDtoForAdd source, CartItem destination, Product destMember, ResolutionContext context)
    {
        return _productRepository.GetByEncodedNameAsync(source.ProductEncodedName).Result!;
    }
}