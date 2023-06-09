using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Commands.RemoveCartItem;
public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    public RemoveCartItemCommandHandler(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }
    public async Task<Unit> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        var foundCarItem = await _cartItemRepository.GetBySessionAndProductEncodedNameAsync(request.Session, request.ProductEncodedName);
        if (foundCarItem != null)
        {
            await _cartItemRepository.DeleteAsync(foundCarItem);
        }
        return Unit.Value;
    }
}