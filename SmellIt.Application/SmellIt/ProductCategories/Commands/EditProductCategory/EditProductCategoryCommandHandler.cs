using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.ProductCategories.Commands.EditProductCategory
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
            var productCategory = (await _productCategoryRepository.GetByEncodedName(request.EncodedName))!;

            if(request.ParentCategoryEncodedName !=null)
                productCategory.ParentCategory = await _productCategoryRepository.GetByEncodedName(request.ParentCategoryEncodedName);
            productCategory.ModifiedAt = DateTime.UtcNow;

            var plTranslation = productCategory.ProductCategoryTranslations.First(fct => fct.Language.Code == "pl-PL");
            plTranslation.Name = request.NamePl;
            plTranslation.Description = request.DescriptionPl;
            plTranslation.ModifiedAt = DateTime.UtcNow;

            var enTranslation = productCategory.ProductCategoryTranslations.First(fct => fct.Language.Code == "en-GB");
            enTranslation.Name = request.NameEn;
            enTranslation.Description = request.DescriptionEn;
            enTranslation.ModifiedAt = DateTime.UtcNow;

            productCategory.EncodeName();
            await _productCategoryRepository.Commit();
            
            return Unit.Value;
        }
    }
}
