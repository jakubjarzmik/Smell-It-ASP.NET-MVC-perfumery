using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.CreateProductCategory;
public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand>
{
    private readonly IUserContext _userContext;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public CreateProductCategoryCommandHandler(IUserContext userContext, IProductCategoryRepository productCategoryRepository, ILanguageRepository languageRepository, IMapper mapper)
    {
        _userContext = userContext;
        _productCategoryRepository = productCategoryRepository;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        var plLanguage = await _languageRepository.GetByCodeAsync("pl-PL");
        var enLanguage = await _languageRepository.GetByCodeAsync("en-GB");

        var productCategory = _mapper.Map<ProductCategory>(request);

        if (plLanguage != null && enLanguage != null)
        {
            productCategory.ProductCategoryTranslations = new List<ProductCategoryTranslation>
            {
                new ProductCategoryTranslation { Language = plLanguage, Name = request.NamePl, Description = request.DescriptionPl },
                new ProductCategoryTranslation { Language = enLanguage, Name = request.NameEn, Description = request.DescriptionEn }
            };
        }

        if (!string.IsNullOrWhiteSpace(request.ParentCategoryEncodedName))
        {
            productCategory.ParentCategory = await _productCategoryRepository.GetAsync(request.ParentCategoryEncodedName);
        }

        await _productCategoryRepository.CreateAsync(productCategory);

        return Unit.Value;
    }
}