using System.Globalization;
using MediatR;
using SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName;

namespace SmellIt.Website.Models;
public class WebsiteTextsService
{
    private readonly IMediator _mediator;

    public WebsiteTextsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public string GetValue(string key)
    {
        var layoutText = _mediator.Send(new GetWebsiteTextByEncodedNameQuery(key.ToLower())).Result;
        if (CultureInfo.CurrentCulture.ToString().Equals("pl-PL"))
            return layoutText.TextPL;
        return layoutText.TextEN;
    }
}