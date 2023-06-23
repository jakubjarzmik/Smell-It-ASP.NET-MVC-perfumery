using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Brands.Queries.GetAllBrandsForWebsite;
using SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;
using SmellIt.Application.Features.Orders.Queries.GetPaginatedOrders;
using SmellIt.Application.Features.Genders.Queries.GetAllGendersForWebsite;
using SmellIt.Application.Features.Orders.Queries.GetOrderById;

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
        var order = await Mediator.Send(new GetOrderByIdQuery(CurrentCulture, id));
        return View(order);
    }

    [Authorize(Roles = "Admin")]
    [Route("{id}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        //await Mediator.Send(new DeleteOrderByEncodedNameCommand(encodedName));
        return RedirectToAction(nameof(Index));
    }
}