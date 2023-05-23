using AutoMapper;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class FragranceCategoryResolver : IValueResolver<ProductDto, Product, FragranceCategory?>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

        public FragranceCategoryResolver(IFragranceCategoryRepository fragranceCategoryRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
        }
        public FragranceCategory? Resolve(ProductDto source, Product destination, FragranceCategory? destMember, ResolutionContext context)
        {
            if (source.FragranceCategory == null) return null;
            return _fragranceCategoryRepository.GetByEncodedName(source.FragranceCategory.EncodedName).Result;
        }
    }
}