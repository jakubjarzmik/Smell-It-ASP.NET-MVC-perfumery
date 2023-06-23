using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.Orders.Queries.GetPaginatedOrders;

public class GetPaginatedOrdersQuery : IRequest<OrdersViewModel>
{
    public string LanguageCode { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedOrdersQuery(string languageCode, int? pageNumber, int pageSize)
    {
        LanguageCode = languageCode;
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}