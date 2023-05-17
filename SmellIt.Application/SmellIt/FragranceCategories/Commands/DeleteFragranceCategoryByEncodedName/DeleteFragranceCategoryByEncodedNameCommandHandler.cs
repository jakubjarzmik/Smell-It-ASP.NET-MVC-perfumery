using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.DeleteFragranceCategoryByEncodedName
{
    public class DeleteFragranceCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteFragranceCategoryByEncodedNameCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

        public DeleteFragranceCategoryByEncodedNameCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
        }

        public async Task<Unit> Handle(DeleteFragranceCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName))!;
            fragranceCategory.IsActive = false;
            fragranceCategory.DeletedAt = DateTime.Now;

            foreach (var fragranceCategoryTranslation in fragranceCategory.FragranceCategoryTranslations)
            {
                fragranceCategoryTranslation.IsActive = false;
                fragranceCategoryTranslation.DeletedAt = DateTime.Now;
            }

            await _fragranceCategoryRepository.Commit();
            return Unit.Value;
        }
    }
}
