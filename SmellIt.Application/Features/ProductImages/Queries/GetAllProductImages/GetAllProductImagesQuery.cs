using MediatR;

namespace SmellIt.Application.Features.ProductImages.Queries.GetAllProductImages
{
    public class GetAllProductImagesQuery : IRequest<IEnumerable<ProductImageDto>>
    {
    }
}
