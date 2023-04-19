using MediatR;

namespace SmellIt.Application.SmellIt.FragranceCategories.Queries.GetAllFragranceCategories
{
    public class GetAllFragranceCategoriesQuery : IRequest<IEnumerable<FragranceCategoryDto>>
    {
    }
}
