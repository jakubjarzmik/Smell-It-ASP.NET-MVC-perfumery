using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.FragranceCategories.Commands.EditFragranceCategory;
public class EditFragranceCategoryCommandHandler : IRequestHandler<EditFragranceCategoryCommand>
{
    private readonly IFragranceCategoryRepository _fragranceCategoryRepository;

    public EditFragranceCategoryCommandHandler(IFragranceCategoryRepository fragranceCategoryRepository)
    {
        _fragranceCategoryRepository = fragranceCategoryRepository;
    }
    public async Task<Unit> Handle(EditFragranceCategoryCommand request, CancellationToken cancellationToken)
    {
        var fragranceCategory = (await _fragranceCategoryRepository.GetByEncodedNameAsync(request.EncodedName))!;
        fragranceCategory.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, fragranceCategory);

        await _fragranceCategoryRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditFragranceCategoryCommand request, FragranceCategory fragranceCategory)
    {
        var translations = new Dictionary<string, (string Name, string? Description)>
        {
            { "pl-PL", (request.NamePl, request.DescriptionPl) },
            { "en-GB", (request.NameEn, request.DescriptionEn) }
        };

        foreach (var translation in translations)
        {
            var fragranceCategoryTranslation = fragranceCategory.FragranceCategoryTranslations.First(fct => fct.Language.Code == translation.Key);
            fragranceCategoryTranslation.Name = translation.Value.Name;
            fragranceCategoryTranslation.Description = translation.Value.Description;
            fragranceCategoryTranslation.ModifiedAt = DateTime.Now;
        }
    }
}
