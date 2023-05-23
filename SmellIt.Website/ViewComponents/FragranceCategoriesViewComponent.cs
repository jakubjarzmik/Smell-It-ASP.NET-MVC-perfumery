using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategoriesForWebsite;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;
public class FragranceCategoriesViewComponent : BaseViewComponent
{
    public FragranceCategoriesViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var fragranceCategories = await Mediator.Send(new GetAllFragranceCategoriesForWebsiteQuery(CurrentCulture));

        return View(fragranceCategories);
    }
}
