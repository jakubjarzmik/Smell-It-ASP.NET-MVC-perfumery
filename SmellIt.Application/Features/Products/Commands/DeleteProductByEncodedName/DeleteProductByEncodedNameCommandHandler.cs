using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Commands.DeleteProductByEncodedName;

public class DeleteProductByEncodedNameCommandHandler : IRequestHandler<DeleteProductByEncodedNameCommand>
{
    private readonly IUserContext _userContext;
    private readonly IProductRepository _productRepository;

    public DeleteProductByEncodedNameCommandHandler(IUserContext userContext, IProductRepository productRepository)
    {
        _userContext = userContext;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductByEncodedNameCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();

        if (currentUser == null || !currentUser.IsInRole("Admin"))
        {
            return Unit.Value;
        }

        await _productRepository.DeleteAsync(request.EncodedName);
        return Unit.Value;
    }
}