using MediatR;
using SmellIt.Application.Features.Payments.DTOs;

namespace SmellIt.Application.Features.Payments.Queries.GetAllPayments;

public class GetAllPaymentsQuery : IRequest<IEnumerable<PaymentDto>>
{
}