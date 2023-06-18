using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Brands.Commands.EditBrand;
public class EditBrandCommandHandler : IRequestHandler<EditBrandCommand>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IUserContext _userContext;

    public EditBrandCommandHandler(IBrandRepository brandRepository, IUserContext userContext)
    {
        _brandRepository = brandRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditBrandCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var brand = (await _brandRepository.GetByEncodedNameAsync(request.EncodedName))!;
        brand.ModifiedAt = DateTime.Now;
        brand.ModifiedById = currentUser.Id;

        UpdateTranslations(request, brand, currentUser.Id);

        await _brandRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditBrandCommand request, Brand brand, string currentUserId)
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
            brandTranslation.ModifiedById = currentUserId;
        }
    }
}
