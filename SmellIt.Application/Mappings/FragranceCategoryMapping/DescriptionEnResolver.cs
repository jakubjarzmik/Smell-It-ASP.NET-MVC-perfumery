using AutoMapper;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping
{
    internal class DescriptionEnResolver : IValueResolver<FragranceCategory, FragranceCategoryDto, string?>
    {
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;

        public DescriptionEnResolver(IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository)
        {
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
        }

        public string? Resolve(FragranceCategory source, FragranceCategoryDto destination, string? destMember, ResolutionContext context)
        {
            var translation = _fragranceCategoryTranslationRepository.GetTranslation(source.Id, "en-GB").Result;
            return translation!.Description;
        }
    }
}
