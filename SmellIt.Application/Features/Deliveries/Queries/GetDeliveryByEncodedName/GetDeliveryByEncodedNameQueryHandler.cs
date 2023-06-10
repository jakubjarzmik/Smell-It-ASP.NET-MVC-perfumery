using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Queries.GetDeliveryByEncodedName;

public class GetDeliveryByEncodedNameQueryHandler : IRequestHandler<GetDeliveryByEncodedNameQuery, DeliveryDto>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public GetDeliveryByEncodedNameQueryHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<DeliveryDto> Handle(GetDeliveryByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var delivery = await _deliveryRepository.GetByEncodedNameAsync(request.EncodedName);
        var dto = _mapper.Map<DeliveryDto>(delivery);
        return dto;
    }
}