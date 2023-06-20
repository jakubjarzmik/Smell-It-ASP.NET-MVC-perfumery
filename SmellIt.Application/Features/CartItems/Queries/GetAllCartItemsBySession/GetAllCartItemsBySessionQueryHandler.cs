using AutoMapper;
using MediatR;
using SmellIt.Application.Features.CartItems.DTOs.Website;
using SmellIt.Application.ViewModels.Website;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
public class GetAllCartItemsBySessionQueryHandler : IRequestHandler<GetAllCartItemsBySessionQuery, CartViewModel>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllCartItemsBySessionQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper, IUserContext userContext)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
        _userContext = userContext;
    }
    public async Task<CartViewModel> Handle(GetAllCartItemsBySessionQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<CartItem> cartItems;
        if (request.IsAuthenticated)
        {
            cartItems = await _cartItemRepository.GetByUserAsync(_userContext.GetCurrentUser()!.Id);
        }
        else
        {
            cartItems = await _cartItemRepository.GetBySessionAsync(request.Session);
        }

        var dtos = _mapper.Map<IEnumerable<CartItemDtoForView>>(cartItems, opt => { opt.Items["LanguageCode"] = request.LanguageCode; });
        var totalPrice = dtos.Sum(dto => dto.Quantity * (dto.PromotionalPrice ?? dto.Price));
        var cartViewModel = new CartViewModel
        {
            CartItems = dtos,
            TotalPrice = totalPrice
        };
        return cartViewModel;
    }
}
