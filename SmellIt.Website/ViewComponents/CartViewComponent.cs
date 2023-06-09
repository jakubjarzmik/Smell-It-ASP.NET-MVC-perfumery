using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;
public class CartViewComponent : BaseViewComponent
{
    public CartViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cartItems = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture));

        return View(cartItems);
    }
}
