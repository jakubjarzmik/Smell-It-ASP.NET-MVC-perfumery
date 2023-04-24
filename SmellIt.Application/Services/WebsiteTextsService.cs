using System.Globalization;
using MediatR;
using SmellIt.Application.SmellIt.WebsiteTexts.Queries.GetWebsiteTextByEncodedName;

namespace SmellIt.Application.Services;
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
        if (layoutText == null)
            return key;
        if (CultureInfo.CurrentCulture.ToString().Equals("pl-PL"))
            return layoutText.TextPL;
        return layoutText.TextEN;
    }
}