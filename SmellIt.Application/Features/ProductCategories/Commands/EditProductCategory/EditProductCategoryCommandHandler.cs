using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.EditProductCategory
{
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

            var plTranslation = productCategory.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL");
            plTranslation.Name = request.NamePl;
            plTranslation.Description = request.DescriptionPl;
            plTranslation.ModifiedAt = DateTime.Now;

            var enTranslation = productCategory.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB");
            enTranslation.Name = request.NameEn;
            enTranslation.Description = request.DescriptionEn;
            enTranslation.ModifiedAt = DateTime.Now;

            productCategory.EncodeName();
            await _productCategoryRepository.CommitAsync();
            
            return Unit.Value;
        }
    }
}
