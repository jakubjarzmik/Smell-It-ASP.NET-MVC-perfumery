using MediatR;

namespace SmellIt.Application.Features.Genders.Queries.GetAllGenders
{
    public class GetAllGendersQuery : IRequest<IEnumerable<GenderDto>>
    {
    }
}
