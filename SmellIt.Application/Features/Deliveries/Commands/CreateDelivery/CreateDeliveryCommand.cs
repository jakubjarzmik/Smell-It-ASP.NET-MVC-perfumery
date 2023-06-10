using MediatR;
using SmellIt.Application.Features.Deliveries.DTOs;

namespace SmellIt.Application.Features.Deliveries.Commands.CreateDelivery;

public class CreateDeliveryCommand : DeliveryDto, IRequest
{

}