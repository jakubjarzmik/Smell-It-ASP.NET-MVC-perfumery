using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.BrandMapping
{
    internal class DescriptionEnResolver : IValueResolver<Brand, BrandDto, string?>
    {
        private readonly IBrandTranslationRepository _brandTranslationRepository;

        public DescriptionEnResolver(IBrandTranslationRepository brandTranslationRepository)
        {
            _brandTranslationRepository = brandTranslationRepository;
        }

        public string? Resolve(Brand source, BrandDto destination, string? destMember, ResolutionContext context)
        {
            var translation = _brandTranslationRepository.GetTranslation(source.Id, "en-GB").Result;
            return translation!.Description;
        }
    }
}
