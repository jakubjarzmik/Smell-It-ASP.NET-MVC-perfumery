using AutoMapper;
using SmellIt.Application.SmellIt.Brands;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.BrandMapping
{
    internal class DescriptionPlResolver : IValueResolver<Brand, BrandDto, string?>
    {
        private readonly IBrandTranslationRepository _brandTranslationRepository;

        public DescriptionPlResolver(IBrandTranslationRepository brandTranslationRepository)
        {
            _brandTranslationRepository = brandTranslationRepository;
        }
        public string? Resolve(Brand source, BrandDto destination, string? destMember, ResolutionContext context)
        {
            var translation = _brandTranslationRepository.GetTranslation(source.Id, "pl-PL").Result;
            return translation!.Description;
        }
    }
}
