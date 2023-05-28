using MediatR;
using SmellIt.Application.Features.ProductImages.DTOs;

namespace SmellIt.Application.Features.ProductImages.Queries.GetAllProductImages;

public class GetAllProductImagesQuery : IRequest<IEnumerable<ProductImageDto>>
{
}