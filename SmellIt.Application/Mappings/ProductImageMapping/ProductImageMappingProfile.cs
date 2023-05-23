using AutoMapper;
using SmellIt.Application.Features.ProductImages.DTOs;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductImageMapping;
public class ProductImageMappingProfile : Profile
{
    public ProductImageMappingProfile()
    {
        CreateMap<ProductImageDto, ProductImage>();
        CreateMap<ProductImage, ProductImageDto>();

    }
}