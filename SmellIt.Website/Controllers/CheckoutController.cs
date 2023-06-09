using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Application.ViewModels.Website;
using SmellIt.Website.Controllers.Abstract;

namespace SmellIt.Website.Controllers;

[Route("checkout")]
public class CheckoutController : BaseController
{
    public CheckoutController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<IActionResult> Index()
    {
        var checkoutViewModel = new CheckoutViewModel
        {
            CartViewModel = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture))
        };
        return View(checkoutViewModel);
    }
}