using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.EditBrand;
public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
{
    private readonly IBrandRepository _brandRepository;

    public EditBrandCommandHandler(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = (await _brandRepository.GetByEncodedNameAsync(request.EncodedName))!;
        brand.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, brand);

        await _brandRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditBrandCommand request, Brand brand)
    {
        var translations = new Dictionary<string, string?>
            {
                { "pl-PL", request.DescriptionPl },
                { "en-GB", request.DescriptionEn }
            };

        foreach (var translation in translations)
        {
            var brandTranslation = brand.BrandTranslations.First(bt => bt.Language.Code == translation.Key);
            brandTranslation.Description = translation.Value;
            brandTranslation.ModifiedAt = DateTime.Now;
        }
    }
}
