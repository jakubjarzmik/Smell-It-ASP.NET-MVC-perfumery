using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.Deliveries.Queries.GetPaginatedDeliveries;

public class GetPaginatedDeliveriesQuery : IRequest<DeliveriesViewModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedDeliveriesQuery(int? pageNumber, int pageSize)
    {
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}