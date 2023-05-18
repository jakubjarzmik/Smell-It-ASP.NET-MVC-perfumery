using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders;

namespace SmellIt.Website.ViewComponents;
public class GendersViewComponent : ViewComponent
{
    private readonly IMediator _mediator;

    public GendersViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genders = await _mediator.Send(new GetAllGendersQuery());

        return View(genders);
    }
}
