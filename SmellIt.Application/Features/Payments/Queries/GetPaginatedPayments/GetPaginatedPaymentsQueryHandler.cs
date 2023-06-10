using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Queries.GetPaginatedPayments;
public class GetPaginatedPaymentsQueryHandler : IRequestHandler<GetPaginatedPaymentsQuery, PaymentsViewModel>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public GetPaginatedPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    public async Task<PaymentsViewModel> Handle(GetPaginatedPaymentsQuery request, CancellationToken cancellationToken)
    {
        var totalPayments = await _paymentRepository.CountAsync();
        var fragranceCategories = await _paymentRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var paymentDtos = _mapper.Map<IEnumerable<PaymentDto>>(fragranceCategories);

        var viewModel = new PaymentsViewModel(paymentDtos, totalPayments, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
