using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Orders.Commands.UpdateOrderStatus;
using SmellIt.Application.Features.Orders.Queries.GetPaginatedOrders;
using SmellIt.Application.Features.Orders.Queries.GetOrderById;
using SmellIt.Application.Features.OrderStatuses.Queries.GetAllOrderStatuses;

namespace SmellIt.Admin.Controllers;

[Authorize(Roles = "Admin,Employee")]
[Route("orders")]
public class OrdersController : BaseController
{
    public OrdersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        var viewModel = await Mediator.Send(new GetPaginatedOrdersQuery(CurrentCulture, pageNumber, 7));
        return View(viewModel);
    }

    [Route("{id}/details")]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.OrderStatuses = new SelectList(await Mediator.Send(new GetAllOrderStatusesQuery(CurrentCulture)), "Id", "Name");
        var order = await Mediator.Send(new GetOrderByIdQuery(CurrentCulture, id));
        return View(order);
    }
    [HttpPost]
    [Route("update-status")]
    public async Task<IActionResult> UpdateStatus(int orderId, int orderStatusId)
    {
        await Mediator.Send(new UpdateOrderStatusCommand(orderId, orderStatusId));

        var newOrderStatus = (await Mediator.Send(new GetOrderByIdQuery(CurrentCulture, orderId))).OrderStatus.Name;

        return Json(new { success = true, orderStatus = newOrderStatus });
    }
}