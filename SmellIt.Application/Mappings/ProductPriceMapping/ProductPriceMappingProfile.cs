using AutoMapper;
using SmellIt.Application.Features.ProductPrices;
using SmellIt.Domain.Entities;

namespace SmellIt.Application.Mappings.ProductPriceMapping;
public class ProductPriceMappingProfile : Profile
{
    public ProductPriceMappingProfile()
    {
        CreateMap<ProductPriceDto, ProductPrice>();
        CreateMap<ProductPrice, ProductPriceDto>();
    }
}