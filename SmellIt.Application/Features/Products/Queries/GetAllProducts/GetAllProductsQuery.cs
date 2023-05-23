using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
