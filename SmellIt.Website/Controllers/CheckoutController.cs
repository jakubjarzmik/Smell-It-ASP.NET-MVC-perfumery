using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveriesForWebsite;
using SmellIt.Application.Features.Orders.Commands.CreateOrder;
using SmellIt.Application.Features.Orders.Queries.GetLatestUserData;
using SmellIt.Application.Features.Payments.Queries.GetAllPaymentsForWebsite;
using SmellIt.Website.Controllers.Abstract;

namespace SmellIt.Website.Controllers;

[Authorize]
[Route("checkout")]
public class CheckoutController : BaseController
{
    public CheckoutController(IMediator mediator) : base(mediator)
    {
    }

    public async Task<IActionResult> Index()
    {
        var cartViewModel = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture, IsAuthenticated));
        ViewBag.CartViewModel = cartViewModel;
        ViewBag.Deliveries = await Mediator.Send(new GetAllDeliveriesForWebsiteQuery(CurrentCulture));
        ViewBag.Payments = await Mediator.Send(new GetAllPaymentsForWebsiteQuery(CurrentCulture));

        var viewmodel = await Mediator.Send(new GetLatestUserDataQuery(Session, CurrentCulture));

        if (!cartViewModel.CartItems.Any())
            return RedirectToAction("Index", "Products");

        return View(viewmodel);
    }
    [HttpPost("place-order")]
    public async Task<IActionResult> PlaceOrder(CreateOrderCommand command)
    {
        await Mediator.Send(command);

        return RedirectToAction("OrderConfirmation");
    }
    [Route("order-confirmation")]
    public IActionResult OrderConfirmation()
    {
        return View();
    }
}