using MediatR;

namespace SmellIt.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>
    {
    }
}
