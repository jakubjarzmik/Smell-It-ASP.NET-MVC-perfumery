using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveriesForWebsite;
public class GetAllDeliveriesForWebsiteQueryHandler : IRequestHandler<GetAllDeliveriesForWebsiteQuery, IEnumerable<WebsiteDeliveryDto>>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IMapper _mapper;

    public GetAllDeliveriesForWebsiteQueryHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        _deliveryRepository = deliveryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteDeliveryDto>> Handle(GetAllDeliveriesForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var fragranceCategories = await _deliveryRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<WebsiteDeliveryDto>>(fragranceCategories, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
