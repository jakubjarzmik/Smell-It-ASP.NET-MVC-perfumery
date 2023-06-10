using MediatR;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommand : PaymentDto, IRequest
{

}