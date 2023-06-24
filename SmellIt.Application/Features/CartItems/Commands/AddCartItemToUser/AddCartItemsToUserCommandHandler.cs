using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Commands.AddCartItemToUser;
public class AddCartItemsToUserCommandHandler : IRequestHandler<AddCartItemsToUserCommand>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;

    public AddCartItemsToUserCommandHandler(ICartItemRepository cartItemRepository, IUserContext userContext, IUserRepository userRepository)
    {
        _cartItemRepository = cartItemRepository;
        _userContext = userContext;
        _userRepository = userRepository;
    }
    public async Task<Unit> Handle(AddCartItemsToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
        {
            return Unit.Value;
        }
        var cartItemsFromSession = (await _cartItemRepository.GetBySessionAsync(request.Session)).ToList();
        var cartItemsFromUser = (await _cartItemRepository.GetByUserAsync(user.Id)).ToList();

        foreach (var cartItem in cartItemsFromSession)
        {
            var currentItem = cartItemsFromUser.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId && ci.Id != cartItem.Id);
            if (currentItem != null)
            {
                currentItem.Quantity += cartItem.Quantity;
                cartItem.IsActive = false;
            }
            else
            {
                cartItem.Session = user.Email!;
                cartItem.UserId = user.Id;
            }
        }

        await _cartItemRepository.CommitAsync();
        return Unit.Value;
    }
}