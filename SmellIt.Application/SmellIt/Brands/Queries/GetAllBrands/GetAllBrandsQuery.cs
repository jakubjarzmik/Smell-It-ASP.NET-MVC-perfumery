using MediatR;

namespace SmellIt.Application.SmellIt.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>
    {
    }
}
