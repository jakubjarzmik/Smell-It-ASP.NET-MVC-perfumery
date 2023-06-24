using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.ViewModels.Website;

public class CheckoutViewModel
{
    public CartViewModel CartViewModel { get; set; } = default!;
    public OrderCreateDto OrderCreateDto { get; set; } = default!;
    public IEnumerable<WebsiteDeliveryDto> Deliveries { get; set; } = default!;
    public IEnumerable<WebsitePaymentDto> Payments { get; set; } = default!;
}