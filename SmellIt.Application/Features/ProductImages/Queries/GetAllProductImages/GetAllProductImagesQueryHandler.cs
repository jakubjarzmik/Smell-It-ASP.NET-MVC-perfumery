using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductImages.Queries.GetAllProductImages;
public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQuery, IEnumerable<ProductImageDto>>
{
    private readonly IProductImageRepository _productImageRepository;
    private readonly IMapper _mapper;

    public GetAllProductImagesQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
    {
        _productImageRepository = productImageRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductImageDto>> Handle(GetAllProductImagesQuery request, CancellationToken cancellationToken)
    {
        var productImages = await _productImageRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<ProductImageDto>>(productImages);
        return dtos;
    }
}
