using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Commands.AddCartItem;
using SmellIt.Application.Features.CartItems.Commands.RemoveCartItem;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Website.Controllers.Abstract;
using SmellIt.Website.Models;

namespace SmellIt.Website.Controllers;

[Route("cart")]
public class CartController : BaseController
{
    public CartController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<IActionResult> Index()
    {
        var cartViewModel = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture));
        if (!cartViewModel.CartItems.Any())
            return RedirectToAction("Index", "Products");
        return View(cartViewModel);
    }

    [Route("add-to-cart")]
    public async Task<IActionResult> AddToCart([FromQuery(Name = "encoded-name")] string encodedName, [FromQuery(Name = "product-quantity")] decimal quantity = 1)
    {
        await Mediator.Send(new AddCartItemCommand
        {
            ProductEncodedName = encodedName,
            Quantity = quantity,
            Session = Session
        });
        return Redirect(Request.Headers["Referer"].ToString());
    }
    [Route("remove-from-card")]
    public async Task<IActionResult> RemoveFromCart(string encodedName)
    {
        await Mediator.Send(new RemoveCartItemCommand
        {
            ProductEncodedName = encodedName,
            Session = Session
        });
        return Redirect(Request.Headers["Referer"].ToString());
    }
    [HttpPost("change-quantity")]
    public async Task<IActionResult> ChangeQuantity([FromBody] QuantityChange quantityChange)
    {
        await Mediator.Send(new AddCartItemCommand
        {
            ProductEncodedName = quantityChange.EncodedName,
            Quantity = quantityChange.Change,
            Session = Session
        });

        var updatedCart = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture));
        var updatedItem = updatedCart.CartItems.First(item => item.ProductEncodedName == quantityChange.EncodedName);
        return Json(new
        {
            newQuantity = updatedItem.Quantity,
            newTotalPrice = updatedItem.TotalPrice,
            newTotalPromotionalPrice = updatedItem.TotalPromotionalPrice,
            newCartTotal = updatedCart.TotalPrice
        });
    }
}