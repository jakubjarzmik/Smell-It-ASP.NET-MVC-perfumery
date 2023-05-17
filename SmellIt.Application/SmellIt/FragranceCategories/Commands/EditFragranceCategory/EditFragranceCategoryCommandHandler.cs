using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.FragranceCategories.Commands.EditFragranceCategory
{
    public class EditFragranceCategoryCommandHandler : IRequestHandler<EditFragranceCategoryCommand>
    {
        private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

        public EditFragranceCategoryCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository)
        {
            _fragranceCategoryRepository = fragranceCategoryRepository;
        }
        public async Task<Unit> Handle(EditFragranceCategoryCommand request, CancellationToken cancellationToken)
        {
            var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedName(request.EncodedName))!;
            fragranceCategory.ModifiedAt = DateTime.Now;

            var plTranslation = fragranceCategory.FragranceCategoryTranslations.First(fct => fct.Language.Code == "pl-PL");
            plTranslation.Name = request.NamePl;
            plTranslation.Description = request.DescriptionPl;
            plTranslation.ModifiedAt = DateTime.Now;

            var enTranslation = fragranceCategory.FragranceCategoryTranslations.First(fct => fct.Language.Code == "en-GB");
            enTranslation.Name = request.NameEn;
            enTranslation.Description = request.DescriptionEn;
            enTranslation.ModifiedAt = DateTime.Now;

            await _fragranceCategoryRepository.Commit();
            
            return Unit.Value;
        }
    }
}
