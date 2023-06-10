using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Commands.CreateDelivery;
public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;
    public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
    {
        var delivery = _mapper.Map<Delivery>(request);
        await _deliveryRepository.CreateAsync(delivery);
        return Unit.Value;
    }
}