using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Payments.Commands.CreatePayment;
public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;
    public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = _mapper.Map<Payment>(request);
        await _paymentRepository.CreateAsync(payment);
        return Unit.Value;
    }
}