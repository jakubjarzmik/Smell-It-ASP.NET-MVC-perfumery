using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;

namespace SmellIt.Application.Features.Deliveries.Queries.GetAllDeliveries;

public class GetAllDeliveriesQuery : IRequest<IEnumerable<DeliveryDto>>
{
}