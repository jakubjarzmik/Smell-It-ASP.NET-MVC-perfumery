using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Payments.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Queries.GetPaymentByEncodedName;

public class GetPaymentByEncodedNameQueryHandler : IRequestHandler<GetPaymentByEncodedNameQuery, PaymentDto>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;

    public GetPaymentByEncodedNameQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    public async Task<PaymentDto> Handle(GetPaymentByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByEncodedNameAsync(request.EncodedName);
        var dto = _mapper.Map<PaymentDto>(payment);
        return dto;
    }
}