using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Commands.AddCartItem;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Website.Controllers.Abstract;

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
        return View(cartViewModel);
    }

    [HttpPost("add-to-card")]
    public async Task<IActionResult> AddToCard([FromForm(Name = "encoded-name")] string encodedName, [FromForm(Name = "product-quantity")] decimal quantity)
    {
        await Mediator.Send(new AddCartItemCommand
        {
            ProductEncodedName = encodedName,
            Quantity = quantity,
            Session = Session
        });
        return RedirectToAction("Index");
    }
}