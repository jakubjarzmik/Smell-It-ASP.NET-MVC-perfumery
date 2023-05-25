using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetProductByEncodedNameForWebsite
{
    public class GetProductByEncodedNameForWebsiteQueryHandler : IRequestHandler<GetProductByEncodedNameForWebsiteQuery, WebsiteProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByEncodedNameForWebsiteQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<WebsiteProductDto> Handle(GetProductByEncodedNameForWebsiteQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByEncodedNameAsync(request.EncodedName);
            var dto = _mapper.Map<WebsiteProductDto>(product, opt =>
            {
                opt.Items["LanguageCode"] = request.LanguageCode;
            });
            return dto;
        }
    }
}
