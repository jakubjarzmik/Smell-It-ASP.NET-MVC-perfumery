using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Queries.GetAllPayments;
public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<PaymentDto>>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _paymentRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<PaymentDto>>(fragranceCategories);
        return dtos;
    }
}
