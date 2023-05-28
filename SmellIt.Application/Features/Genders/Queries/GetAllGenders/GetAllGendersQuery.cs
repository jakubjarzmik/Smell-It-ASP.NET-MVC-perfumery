using MediatR;
using SmellIt.Application.Features.Genders.DTOs;

namespace SmellIt.Application.Features.Genders.Queries.GetAllGenders;

public class GetAllGendersQuery : IRequest<IEnumerable<GenderDto>>
{
}