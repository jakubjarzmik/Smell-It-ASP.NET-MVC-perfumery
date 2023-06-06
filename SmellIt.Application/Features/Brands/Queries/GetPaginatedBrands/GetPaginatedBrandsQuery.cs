using MediatR;
using SmellIt.Application.ViewModels.Admin;

namespace SmellIt.Application.Features.Brands.Queries.GetPaginatedBrands;

public class GetPaginatedBrandsQuery : IRequest<BrandsViewModel>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedBrandsQuery(int? pageNumber, int pageSize)
    {
        PageNumber = pageNumber ?? 1;
        PageSize = pageSize;
    }
}