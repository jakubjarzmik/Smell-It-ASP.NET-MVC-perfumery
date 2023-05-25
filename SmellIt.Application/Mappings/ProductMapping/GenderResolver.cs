using AutoMapper;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.ProductMapping
{
    public class GenderResolver : IValueResolver<ProductDto, Product, Gender?>
    {
        private readonly IGenderRepository _genderRepository;

        public GenderResolver(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        public Gender? Resolve(ProductDto source, Product destination, Gender? destMember, ResolutionContext context)
        {
            if (source.Gender == null) return null;
            return _genderRepository.GetById(source.Gender.Id).Result;
        }
    }
}