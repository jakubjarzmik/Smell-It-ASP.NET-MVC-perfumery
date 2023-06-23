using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetAsync(request.Id);
        var dto = _mapper.Map<OrderDto>(order, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dto;
    }
}