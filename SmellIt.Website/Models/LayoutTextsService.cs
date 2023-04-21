using System.Globalization;
using MediatR;
using SmellIt.Application.SmellIt.LayoutTexts.Queries.GetLayoutTextByEncodedName;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Website.Models;
public class LayoutTextsService
{
    private readonly IMediator _mediator;

    public LayoutTextsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public string GetValue(string key)
    {
        var layoutText = _mediator.Send(new GetLayoutTextByEncodedNameQuery(key.ToLower())).Result;
        if (CultureInfo.CurrentCulture.ToString().Equals("pl-PL"))
            return layoutText.TextPL;
        return layoutText.TextEN;
    }
}