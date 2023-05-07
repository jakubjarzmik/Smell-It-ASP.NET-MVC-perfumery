using MediatR;

namespace SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders
{
    public class GetAllGendersQuery : IRequest<IEnumerable<GenderDto>>
    {
    }
}
