using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.ProductCategories.Commands.DeleteProductCategoryByEncodedName
{
    public class DeleteProductCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteProductCategoryByEncodedNameCommand>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public DeleteProductCategoryByEncodedNameCommandHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<Unit> Handle(DeleteProductCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var productCategory = (await _productCategoryRepository.GetByEncodedName(request.EncodedName))!;
            productCategory.IsActive = false;
            productCategory.DeletedAt = DateTime.Now;

            foreach (var productCategoryTranslation in productCategory.ProductCategoryTranslations)
            {
                productCategoryTranslation.IsActive = false;
                productCategoryTranslation.DeletedAt = DateTime.Now;
            }

            await _productCategoryRepository.Commit();
            return Unit.Value;
        }
    }
}
