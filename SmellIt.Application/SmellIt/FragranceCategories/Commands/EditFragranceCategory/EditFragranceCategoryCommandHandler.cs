using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory
{
    public class EditFragranceCategoryCommandHandler : IRequestHandler<EditFragranceCategoryCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;

        public EditFragranceCategoryCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository, 
            IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
        }
        public async Task<Unit> Handle(EditFragranceCategoryCommand request, CancellationToken cancellationToken)
        {
            var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName))!;
            fragranceCategory.ModifiedAt = DateTime.UtcNow;

            var plTranslation = (await _fragranceCategoryTranslationRepository.GetTranslation(fragranceCategory.Id, "pl-PL"))!;
            plTranslation.Name = request.NamePL;
            plTranslation.Description = request.DescriptionPL;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = (await _fragranceCategoryTranslationRepository.GetTranslation(fragranceCategory.Id, "en-GB"))!;
            enTranslation.Name = request.NameEN;
            enTranslation.Description = request.DescriptionEN;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            await _fragranceCategoryRepository.Commit();
            
            return Unit.Value;
        }
    }
}
