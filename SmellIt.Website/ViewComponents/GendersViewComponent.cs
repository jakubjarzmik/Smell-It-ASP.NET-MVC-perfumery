using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmellIt.Application.SmellIt.Genders.Queries.GetAllGendersForWebsite;
using SmellIt.Website.ViewComponents.Abstract;

namespace SmellIt.Website.ViewComponents;
public class GendersViewComponent : BaseViewComponent
{
    public GendersViewComponent(IMediator mediator) : base(mediator)
    {
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var genders = await Mediator.Send(new GetAllGendersForWebsiteQuery(CurrentCulture));

        return View(genders);
    }
}
