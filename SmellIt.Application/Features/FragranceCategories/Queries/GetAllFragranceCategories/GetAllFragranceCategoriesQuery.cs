using MediatR;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetAllFragranceCategories
{
    public class GetAllFragranceCategoriesQuery : IRequest<IEnumerable<FragranceCategoryDto>>
    {
    }
}
