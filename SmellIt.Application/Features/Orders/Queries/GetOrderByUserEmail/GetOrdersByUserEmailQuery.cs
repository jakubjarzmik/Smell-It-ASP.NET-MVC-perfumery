using MediatR;
using SmellIt.Application.Features.Orders.DTOs;

namespace SmellIt.Application.Features.Orders.Queries.GetOrderByUserEmail;

public class GetOrdersByUserEmailQuery : IRequest<IEnumerable<OrderDto>>
{
    public string LanguageCode { get; set; }
    public string UserEmail { get; set; }

    public GetOrdersByUserEmailQuery(string languageCode, string userEmail)
    {
        LanguageCode = languageCode;
        UserEmail = userEmail;
    }
}