using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class OrdersViewModel : PaginatedViewModel<OrderDto>
{
    public OrdersViewModel(IEnumerable<OrderDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}