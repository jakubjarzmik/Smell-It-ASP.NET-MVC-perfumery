using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveries;
public class GetAllDeliveriesQueryHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<DeliveryDto>>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public GetAllDeliveriesQueryHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DeliveryDto>> Handle(GetAllDeliveriesQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _deliveryRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<DeliveryDto>>(fragranceCategories);
        return dtos;
    }
}
