using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Admin.Controllers.Abstract;
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
        var viewModel = await Mediator.Send(new GetPaginatedUsersQuery(CurrentCulture, pageNumber, 7));
        return View(viewModel);
    }
    [Route("{id}/delete")]
    public async Task<IActionResult> Delete(string id)
    {
        await Mediator.Send(new DeleteUserByIdCommand(id));
        return RedirectToAction(nameof(Index));
    }
}