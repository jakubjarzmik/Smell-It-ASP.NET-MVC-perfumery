using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.Features.FragranceCategories.Queries.GetPaginatedFragranceCategories;

public class GetPaginatedFragranceCategoriesQuery : IRequest<FragranceCategoriesViewModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedFragranceCategoriesQuery(int? pageNumber, int pageSize)
    {
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}