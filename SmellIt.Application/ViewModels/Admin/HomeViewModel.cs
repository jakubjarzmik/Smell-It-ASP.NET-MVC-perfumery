using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.Features.Users.DTOs;

namespace SmellIt.Application.ViewModels.Admin;

public class HomeViewModel
{
    public int ProductsCount { get; set; }
    public int MonthlyPurchases { get; set; }
    public int MonthlyEarnings { get; set; }
    public int UsersCount { get; set; }
    public IEnumerable<OrderDto> RecentOrders { get; set; } = default!;
    public IEnumerable<ProductDto> MostPopularProducts { get; set; } = default!;
}