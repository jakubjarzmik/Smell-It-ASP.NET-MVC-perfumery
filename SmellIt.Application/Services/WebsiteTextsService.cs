using System.Globalization;
using MediatR;
using SmellIt.Application.Features.WebsiteTexts.Queries.GetWebsiteTextByKey;

namespace SmellIt.Application.Services;
public class WebsiteTextsService
{
    private readonly IMediator _mediator;

    public WebsiteTextsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<string> GetValueAsync(string key)
    {
        var websiteText =  await _mediator.Send(new GetWebsiteTextByKeyQuery(key, CultureInfo.CurrentCulture.ToString()));
        if (websiteText == null!)
            return key;
        return websiteText.Text;
    }
}