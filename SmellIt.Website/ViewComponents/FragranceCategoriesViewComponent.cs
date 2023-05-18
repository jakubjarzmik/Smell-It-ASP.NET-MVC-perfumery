using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.FragranceCategories.Queries.GetAllFragranceCategories;

namespace SmellIt.Website.ViewComponents;
public class FragranceCategoriesViewComponent : ViewComponent
{
    private readonly IMediator _mediator;

    public FragranceCategoriesViewComponent(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var brands = await _mediator.Send(new GetAllFragranceCategoriesQuery());

        return View(brands);
    }
}
