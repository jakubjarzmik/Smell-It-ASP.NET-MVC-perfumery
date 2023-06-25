using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Orders.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Queries.GetOrderByUserEmail;

public class GetOrderByUserEmailQueryHandler : IRequestHandler<GetOrdersByUserEmailQuery, IEnumerable<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetOrderByUserEmailQueryHandler(IOrderRepository orderRepository,IUserRepository userRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<OrderDto>> Handle(GetOrdersByUserEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.UserEmail);

        if (user == null)
        {
            return Enumerable.Empty<OrderDto>();
        }

        var order = await _orderRepository.GetAllAsync(user);
        var dto = _mapper.Map<IEnumerable<OrderDto>>(order, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });

        return dto;
    }
}