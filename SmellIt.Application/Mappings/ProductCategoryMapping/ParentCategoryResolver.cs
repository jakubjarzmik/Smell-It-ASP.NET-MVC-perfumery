using AutoMapper;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;
using SmellIt.Application.Features.ProductCategories.DTOs;

namespace SmellIt.Application.Mappings.ProductCategoryMapping;
public class ParentCategoryResolver : IValueResolver<ProductCategoryDto, ProductCategory, ProductCategory?>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ParentCategoryResolver(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public ProductCategory? Resolve(ProductCategoryDto source, ProductCategory destination, ProductCategory? destMember, ResolutionContext context)
    {
        if(source.ParentCategory != null)
            return _productCategoryRepository.GetByEncodedName(source.ParentCategory.EncodedName!).Result;
        return null;
    }
}