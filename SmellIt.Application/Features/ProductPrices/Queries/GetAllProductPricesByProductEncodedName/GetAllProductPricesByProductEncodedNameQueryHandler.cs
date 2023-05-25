using AutoMapper;
using MediatR;
using SmellIt.Application.Features.ProductPrices.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductPrices.Queries.GetAllProductPricesByProductEncodedName;
public class GetAllProductPricesByProductEncodedNameQueryHandler : IRequestHandler<GetAllProductPricesByProductEncodedNameQuery, IEnumerable<ProductPriceDto>>
{
    private readonly IProductPriceRepository _productPriceRepository;
    private readonly IMapper _mapper;

    public GetAllProductPricesByProductEncodedNameQueryHandler(IProductPriceRepository productPriceRepository, IMapper mapper)
    {
        _productPriceRepository = productPriceRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductPriceDto>> Handle(GetAllProductPricesByProductEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var productPrices = await _productPriceRepository.GetByProductEncodedName(request.EncodedName);
        var dtos = _mapper.Map<IEnumerable<ProductPriceDto>>(productPrices);
        return dtos;
    }
}
