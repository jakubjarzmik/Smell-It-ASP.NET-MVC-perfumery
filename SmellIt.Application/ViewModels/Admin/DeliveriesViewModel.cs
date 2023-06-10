using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class DeliveriesViewModel : PaginatedViewModel<DeliveryDto>
{
    public DeliveriesViewModel(IEnumerable<DeliveryDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}