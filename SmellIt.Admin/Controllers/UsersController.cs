using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
using SmellIt.Application.Features.Orders.Commands.UpdateOrderStatus;
using SmellIt.Application.Features.Orders.Queries.GetOrderById;
using SmellIt.Application.Features.Roles.Queries.GetAllRoles;
using SmellIt.Application.Features.Users.Commands.ChangeUserRole;
using SmellIt.Application.Features.Users.Commands.DeleteUserById;
using SmellIt.Application.Features.Users.Queries.GetPaginatedUsers;

namespace SmellIt.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Route("users")]
public class UsersController : BaseController
{
    public UsersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }
    public async Task<IActionResult> Index([FromQuery(Name = "page-number")] int? pageNumber)
    {
        ViewBag.Roles = await Mediator.Send(new GetAllRolesQuery());

        var viewModel = await Mediator.Send(new GetPaginatedUsersQuery(CurrentCulture, pageNumber, 7));
        return View(viewModel);
    }
    [HttpPost]
    [Route("change-role")]
    public async Task<IActionResult> ChangeRole(string userEmail, IEnumerable<string> roles)
    {
        if(userEmail != "admin@smellit.com")
        {
            await Mediator.Send(new ChangeUserRoleCommand(userEmail, roles));

            return Json(new { success = true });
        }
        return Json(new { success = false });
    }

    [Route("{id}/delete")]
    public async Task<IActionResult> Delete(string id)
    {
        await Mediator.Send(new DeleteUserByIdCommand(id));
        return RedirectToAction(nameof(Index));
    }
}