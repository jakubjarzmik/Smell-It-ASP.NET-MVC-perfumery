using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Commands.DeleteProductByEncodedName
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
            await _productRepository.DeleteByEncodedNameAsync(request.EncodedName);
            return Unit.Value;
        }
    }
}
