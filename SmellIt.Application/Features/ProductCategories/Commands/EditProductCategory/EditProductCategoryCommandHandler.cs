using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory;
public class EditProductCategoryCommandHandler : IRequestHandler<EditProductCategoryCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IUserContext _userContext;

    public EditProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IUserContext userContext)
    {
        _productCategoryRepository = productCategoryRepository;
        _userContext = userContext;
    }
    public async Task<Unit> Handle(EditProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var productCategory = (await _productCategoryRepository.GetByEncodedNameAsync(request.EncodedName))!;

        if (!string.IsNullOrWhiteSpace(request.ParentCategoryEncodedName))
            productCategory.ParentCategory = await _productCategoryRepository.GetByEncodedNameAsync(request.ParentCategoryEncodedName!);

        productCategory.ModifiedAt = DateTime.Now;
        productCategory.ModifiedById = currentUser.Id;

        UpdateTranslations(request, productCategory, currentUser.Id);

        productCategory.EncodeName();
        await _productCategoryRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditProductCategoryCommand request, ProductCategory productCategory, string currentUserId)
    {
        var translations = new Dictionary<string, (string Name, string? Description)>
        {
            { "pl-PL", (request.NamePl, request.DescriptionPl) },
            { "en-GB", (request.NameEn, request.DescriptionEn) }
        };

        foreach (var translation in translations)
        {
            var productCategoryTranslation = productCategory.ProductCategoryTranslations.First(pct => pct.Language.Code == translation.Key);
            productCategoryTranslation.Name = translation.Value.Name;
            productCategoryTranslation.Description = translation.Value.Description;
            productCategoryTranslation.ModifiedAt = DateTime.Now;
            productCategoryTranslation.ModifiedById = currentUserId;
        }
    }
}