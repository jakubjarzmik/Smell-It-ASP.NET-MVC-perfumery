using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetProductsByCategoryEncodedName
{
    public class GetProductsByCategoryEncodedNameQueryHandler : IRequestHandler<GetProductsByCategoryEncodedNameQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryEncodedNameQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategoryEncodedNameAsync(request.EncodedName);
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return dtos;
        }
    }
}
