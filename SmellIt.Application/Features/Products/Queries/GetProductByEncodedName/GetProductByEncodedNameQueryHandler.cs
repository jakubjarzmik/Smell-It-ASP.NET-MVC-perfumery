using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedName;

public class GetProductByEncodedNameQueryHandler : IRequestHandler<GetProductByEncodedNameQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByEncodedNameQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDto> Handle(GetProductByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByEncodedNameAsync(request.EncodedName);
        var dto = _mapper.Map<ProductDto>(product);
        return dto;
    }
}