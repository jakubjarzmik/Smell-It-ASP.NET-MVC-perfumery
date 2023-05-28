using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.DeleteProductCategoryByEncodedName;

public class DeleteProductCategoryByEncodedNameCommandHandler : IRequestHandler<DeleteProductCategoryByEncodedNameCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public DeleteProductCategoryByEncodedNameCommandHandler(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<Unit> Handle(DeleteProductCategoryByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        await _productCategoryRepository.DeleteByEncodedNameAsync(request.EncodedName);
        return Unit.Value;
    }
}