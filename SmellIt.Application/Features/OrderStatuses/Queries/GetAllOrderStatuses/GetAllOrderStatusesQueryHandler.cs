using AutoMapper;
using MediatR;
using SmellIt.Application.Features.OrderStatuses.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.OrderStatuses.Queries.GetAllOrderStatuses;
public class GetAllOrderStatusesQueryHandler : IRequestHandler<GetAllOrderStatusesQuery, IEnumerable<OrderStatusDto>>
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public GetAllOrderStatusesQueryHandler(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<OrderStatusDto>> Handle(GetAllOrderStatusesQuery request, CancellationToken cancellationToken)
    {
        var orderStatuss = await _orderStatusRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<OrderStatusDto>>(orderStatuss, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
