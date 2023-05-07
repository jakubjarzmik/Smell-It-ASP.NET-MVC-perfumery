using MediatR;
using SmellIt.Application.SmellIt.FragranceCategories;

namespace SmellIt.Application.SmellIt.Genders.Queries.GetAllGenders
{
    public class GetAllGendersQuery : IRequest<IEnumerable<GenderDto>>
    {
    }
}
