using MediatR;
using SmellIt.Application.Features.Orders.DTOs;

namespace SmellIt.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDto>
{
    public string LanguageCode { get; set; }
    public int Id { get; set; }

    public GetOrderByIdQuery(string languageCode, int id)
    {
        LanguageCode = languageCode;
        Id = id;
    }
}