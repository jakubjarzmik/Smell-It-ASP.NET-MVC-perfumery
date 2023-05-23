using MediatR;
using SmellIt.Application.Features.Brands.DTOs;

namespace SmellIt.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<BrandDto>>
    {
    }
}
