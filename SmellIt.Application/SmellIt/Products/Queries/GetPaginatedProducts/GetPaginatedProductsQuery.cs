using MediatR;
using SmellIt.Application.ViewModels;

namespace SmellIt.Application.SmellIt.Products.Queries.GetPaginatedProducts
{
    public class GetPaginatedProductsQuery : IRequest<ProductsViewModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedProductsQuery(int? pageNumber, int pageSize)
        {
            PageNumber = pageNumber ?? 1;
            PageSize = pageSize;
        }
    }
}
