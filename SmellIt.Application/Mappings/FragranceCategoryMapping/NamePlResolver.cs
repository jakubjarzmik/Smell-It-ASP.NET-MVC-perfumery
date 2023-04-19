using AutoMapper;
using SmellIt.Application.SmellIt.FragranceCategories;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Mappings.FragranceCategoryMapping
{
    internal class NamePlResolver : IValueResolver<FragranceCategory, FragranceCategoryDto, string>
    {
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;
        private readonly ILanguageRepository _languageRepository;

        public NamePlResolver(IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository, ILanguageRepository languageRepository)
        {
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
            _languageRepository = languageRepository;
        }

        public string Resolve(FragranceCategory source, FragranceCategoryDto destination, string destMember, ResolutionContext context)
        {
            var languageId = _languageRepository.GetByCode("pl-PL").Result!.Id;
            var translation = _fragranceCategoryTranslationRepository.GetByFragranceCategoryId(source.Id).Result.FirstOrDefault(t => t.LanguageId == languageId);
            return translation!.Name;
        }
    }
}
