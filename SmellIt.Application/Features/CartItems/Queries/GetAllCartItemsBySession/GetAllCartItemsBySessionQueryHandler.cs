using AutoMapper;
using MediatR;
using SmellIt.Application.Features.CartItems.DTOs;
using SmellIt.Application.ViewModels.Website;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
public class GetAllCartItemsBySessionQueryHandler : IRequestHandler<GetAllCartItemsBySessionQuery, CartViewModel>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public GetAllCartItemsBySessionQueryHandler(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }
    public async Task<CartViewModel> Handle(GetAllCartItemsBySessionQuery request, CancellationToken cancellationToken)
    {
        var cartItems = await _cartItemRepository.GetBySessionAsync(request.Session);
        var dtos = _mapper.Map<IEnumerable<CartItemDto>>(cartItems, opt => { opt.Items["LanguageCode"] = request.LanguageCode; });
        var totalPrice = dtos.Sum(dto => dto.Quantity * (dto.Product?.PromotionalPrice?.Value ?? dto.Product?.Price.Value)) ?? 0;
        var cartViewModel = new CartViewModel
        {
            CartItems = dtos,
            TotalPrice = totalPrice
        };
        return cartViewModel;
    }
}
