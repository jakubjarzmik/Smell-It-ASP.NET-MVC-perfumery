using MediatR;
using SmellIt.Application.Features.Orders.Commands.CreateOrder;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Orders.Queries.GetLatestUserData;

public class GetLatestUserDataQueryHandler : IRequestHandler<GetLatestUserDataQuery, CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserContext _userContext;
    private readonly IUserRepository _userRepository;

    public GetLatestUserDataQueryHandler(IOrderRepository orderRepository, IUserContext userContext, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _userContext = userContext;
        _userRepository = userRepository;
    }
    public async Task<CreateOrderCommand> Handle(GetLatestUserDataQuery request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        var latestOrder = await _orderRepository.GetLatestUserOrderAsync(currentUser!.Id);
        var user = await _userRepository.GetAsync(currentUser.Id);
        return new CreateOrderCommand
        {
            PhoneNumber = latestOrder?.PhoneNumber ?? user?.PhoneNumber ?? "",
            UserEmail = latestOrder?.User.Email ?? user?.Email ?? "",
            DeliveryId = latestOrder?.DeliveryId ?? 1,
            PaymentId = latestOrder?.PaymentId ?? 1,
            FullName = latestOrder?.Address.FullName ?? "",
            FirstLine = latestOrder?.Address.FirstLine ?? "",
            SecondLine = latestOrder?.Address.SecondLine,
            PostalCode = latestOrder?.Address.PostalCode ?? "",
            City = latestOrder?.Address.City ?? ""
        };
    }
}