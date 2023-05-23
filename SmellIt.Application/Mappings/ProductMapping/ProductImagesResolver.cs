using AutoMapper;
using SmellIt.Application.Features.Products;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class ProductImagesResolver : IValueResolver<ProductDto, Product, ICollection<ProductImage>?>
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesResolver(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public ICollection<ProductImage>? Resolve(ProductDto source, Product destination, ICollection<ProductImage>? destMember, ResolutionContext context)
        {
            return _productImageRepository.GetByProductId(destination.Id).Result;
        }
    }
}