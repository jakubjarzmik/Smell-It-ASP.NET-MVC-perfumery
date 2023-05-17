using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Products.Commands.DeleteProductByEncodedName
{
    public class DeleteProductByEncodedNameCommandHandler : IRequestHandler<DeleteProductByEncodedNameCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductByEncodedNameCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var product = (await _productRepository.GetByEncodedName(request.EncodedName))!;
            product.IsActive = false;
            product.DeletedAt = DateTime.Now;

            foreach (var productTranslation in product.ProductTranslations)
            {
                productTranslation.IsActive = false;
                productTranslation.DeletedAt = DateTime.Now;
            }

            foreach (var productPrice in product.ProductPrices)
            {
                productPrice.IsActive = false;
                productPrice.DeletedAt = DateTime.Now;
            }

            await _productRepository.Commit();
            return Unit.Value;
        }
    }
}
