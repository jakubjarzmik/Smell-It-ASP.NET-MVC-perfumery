using AutoMapper;
using MediatR;
using SmellIt.Application.Features.OrderStatuses.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.OrderStatuses.Queries.GetCanceledOrderStatus;
public class GetReceivedOrderStatusQueryHandler : IRequestHandler<GetReceivedOrderStatusQuery, OrderStatusDto>
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public GetReceivedOrderStatusQueryHandler(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }
    public async Task<OrderStatusDto> Handle(GetReceivedOrderStatusQuery request, CancellationToken cancellationToken)
    {
        var orderStatuss = await _orderStatusRepository.GetByNameAsync("Received");
        var dtos = _mapper.Map<OrderStatusDto>(orderStatuss, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
