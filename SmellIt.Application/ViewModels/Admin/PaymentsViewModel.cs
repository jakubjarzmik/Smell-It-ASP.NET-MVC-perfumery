using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Application.ViewModels.Abstract;

namespace SmellIt.Application.ViewModels.Admin;

public class PaymentsViewModel : PaginatedViewModel<PaymentDto>
{
    public PaymentsViewModel(IEnumerable<PaymentDto> items, int totalItems, int currentPage, int pageSize) : base(items, totalItems, currentPage, pageSize)
    {
    }
}