using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Application.Features.CartItems.Queries.GetAllCartItemsBySession;
using SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveriesForWebsite;
using SmellIt.Application.Features.Orders.Commands.CancelOrder;
using SmellIt.Application.Features.Orders.Commands.CreateOrder;
using SmellIt.Application.Features.Orders.Commands.UpdateOrderStatus;
using SmellIt.Application.Features.Orders.Queries.GetLatestUserData;
using SmellIt.Application.Features.Orders.Queries.GetOrderById;
using SmellIt.Application.Features.Orders.Queries.GetOrderByUserEmail;
using SmellIt.Application.Features.OrderStatuses.Queries.GetAllOrderStatuses;
using SmellIt.Application.Features.OrderStatuses.Queries.GetCanceledOrderStatus;
using SmellIt.Application.Features.Payments.Queries.GetAllPaymentsForWebsite;
using SmellIt.Domain.Interfaces;
using SmellIt.Domain.Models;
using SmellIt.Website.Controllers.Abstract;

namespace SmellIt.Website.Controllers;

[Authorize]
[Route("orders")]
public class OrdersController : BaseController
{
    private readonly IUserContext _userContext;

    public OrdersController(IMediator mediator, IUserContext userContext) : base(mediator)
    {
        _userContext = userContext;
    }

    public async Task<IActionResult> Index()
    {
        var viewmodel = await Mediator.Send(new GetOrdersByUserEmailQuery(CurrentCulture, _userContext.GetCurrentUser()!.Email));

        return View(viewmodel);
    }
    [Route("{id}/details")]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.ReceivedOrderStatus = await Mediator.Send(new GetReceivedOrderStatusQuery(CurrentCulture));
        var order = await Mediator.Send(new GetOrderByIdQuery(CurrentCulture, id));
        return View(order);
    }
    [HttpPost]
    [Route("cancel-order")]
    public async Task<IActionResult> CancelOrder(int orderId)
    {
        await Mediator.Send(new CancelOrderCommand(orderId));

        var newOrderStatus = (await Mediator.Send(new GetOrderByIdQuery(CurrentCulture, orderId))).OrderStatus.Name;

        return Json(new { success = true, orderStatus = newOrderStatus });
    }
}