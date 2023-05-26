using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory;
public class EditProductCategoryCommandHandler : IRequestHandler<EditProductCategoryCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public EditProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(EditProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var productCategory = (await _productCategoryRepository.GetByEncodedNameAsync(request.EncodedName))!;

        if (!string.IsNullOrWhiteSpace(request.ParentCategoryEncodedName))
            productCategory.ParentCategory = await _productCategoryRepository.GetByEncodedNameAsync(request.ParentCategoryEncodedName!);

        productCategory.ModifiedAt = DateTime.Now;

        UpdateTranslations(request, productCategory);

        productCategory.EncodeName();
        await _productCategoryRepository.CommitAsync();

        return Unit.Value;
    }
    private void UpdateTranslations(EditProductCategoryCommand request, ProductCategory productCategory)
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
        }
    }
}