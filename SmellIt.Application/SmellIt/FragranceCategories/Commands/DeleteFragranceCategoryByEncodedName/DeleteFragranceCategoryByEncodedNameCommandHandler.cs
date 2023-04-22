using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName
{
    public class DeleteFragranceCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteFragranceCategoryByEncodedNameCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;
        private readonly IFragranceCategoryTranslationRepository _fragranceCategoryTranslationRepository;

        public DeleteFragranceCategoryByEncodedNameCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository, IFragranceCategoryTranslationRepository fragranceCategoryTranslationRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
            _fragranceCategoryTranslationRepository = fragranceCategoryTranslationRepository;
        }

        public async Task<Unit> Handle(DeleteFragranceCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName))!;
            fragranceCategory.IsActive = false;
            fragranceCategory.DeletedAt = DateTime.UtcNow;

            var fragranceCategoryTranslations = await _fragranceCategoryTranslationRepository.GetFragranceCategoryTranslations(fragranceCategory.Id);
            foreach (var fragranceCategoryTranslation in fragranceCategoryTranslations)
            {
                fragranceCategoryTranslation.IsActive = false;
                fragranceCategoryTranslation.DeletedAt = DateTime.UtcNow;
            }

            await _fragranceCategoryRepository.Commit();
            return Unit.Value;
        }
    }
}
