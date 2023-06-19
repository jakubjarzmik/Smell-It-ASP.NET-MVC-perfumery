using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveriesForWebsite;
using SmellIt.Application.Features.Payments.Queries.GetAllPaymentsForWebsite;
using SmellIt.Application.ViewModels.Website;
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
        var checkoutViewModel = new CheckoutViewModel
        {
            CartViewModel = await Mediator.Send(new GetAllCartItemsBySessionQuery(Session, CurrentCulture)),
            Deliveries = await Mediator.Send(new GetAllDeliveriesForWebsiteQuery(CurrentCulture)),
            Payments = await Mediator.Send(new GetAllPaymentsForWebsiteQuery(CurrentCulture))
        };
        if (!checkoutViewModel.CartViewModel.CartItems.Any())
            return RedirectToAction("Index", "Products");
        return View(checkoutViewModel);
    }
    [Route("order-confirmation")]
    public IActionResult OrderConfirmation()
    {
        return View();
    }
}