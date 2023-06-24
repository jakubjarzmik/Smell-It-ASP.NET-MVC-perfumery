using MediatR;
using SmellIt.Application.Features.Orders.Commands.CreateOrder;

namespace SmellIt.Application.Features.Orders.Queries.GetLatestUserData;

public class GetLatestUserDataQuery : IRequest<CreateOrderCommand>
{
    public string Session;
    public string LanguageCode { get; set; }

    public GetLatestUserDataQuery(string session, string languageCode)
    {
        Session = session;
        LanguageCode = languageCode;
    }
}