using MediatR;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.Features.Payments.Commands.EditPayment;

public class EditPaymentCommand : PaymentDto, IRequest
{

}