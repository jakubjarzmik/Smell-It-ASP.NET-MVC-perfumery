using MediatR;

namespace SmellIt.Application.SmellIt.ProductImages.Queries.GetAllProductImages
{
    public class GetAllProductImagesQuery : IRequest<IEnumerable<ProductImageDto>>
    {
    }
}
