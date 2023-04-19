using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory
{
    public class EditFragranceCategoryCommandHandler : IRequestHandler<EditFragranceCategoryCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;
        private readonly ILanguageRepository _languageRepository;

        public EditFragranceCategoryCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository, 
            IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository, ILanguageRepository languageRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
            _languageRepository = languageRepository;
        }
        public async Task<Unit> Handle(EditFragranceCategoryCommand request, CancellationToken cancellationToken)
        {
            var polishId = _languageRepository.GetByCode("pl-PL").Result!.Id;
            var englishId = _languageRepository.GetByCode("en-GB").Result!.Id;

            var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName))!;


            var fragranceCategoryTranslations = (await _fragranceCategoryTranslationRepository.GetByFragranceCategoryId(fragranceCategory.Id)).ToList();

            var plFragranceCategoryTranslation = fragranceCategoryTranslations.FirstOrDefault(bt => bt.LanguageId == polishId)!;
            plFragranceCategoryTranslation.Name = request.NamePL;
            plFragranceCategoryTranslation.Description = request.DescriptionPL;

            var enFragranceCategoryTranslation = fragranceCategoryTranslations.FirstOrDefault(bt => bt.LanguageId == englishId)!;
            enFragranceCategoryTranslation.Name = request.NameEN;
            enFragranceCategoryTranslation.Description = request.DescriptionEN;

            await _fragranceCategoryRepository.Commit();
            
            return Unit.Value;
        }
    }
}
