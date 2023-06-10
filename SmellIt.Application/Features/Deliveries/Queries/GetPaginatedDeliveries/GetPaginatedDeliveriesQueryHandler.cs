using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Queries.GetPaginatedDeliveries;
public class GetPaginatedDeliveriesQueryHandler : IRequestHandler<GetPaginatedDeliveriesQuery, DeliveriesViewModel>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public GetPaginatedDeliveriesQueryHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<DeliveriesViewModel> Handle(GetPaginatedDeliveriesQuery request, CancellationToken cancellationToken)
    {
        var totalDeliveries = await _deliveryRepository.CountAsync();
        var fragranceCategories = await _deliveryRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var deliveryDtos = _mapper.Map<IEnumerable<DeliveryDto>>(fragranceCategories);

        var viewModel = new DeliveriesViewModel(deliveryDtos, totalDeliveries, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
