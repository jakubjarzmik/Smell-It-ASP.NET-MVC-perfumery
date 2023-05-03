using AutoMapper;
using MediatR;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.ProductCategories.Queries.GetProductCategoryByEncodedName
{
    public class GetProductCategoryByEncodedNameQueryHandler : IRequestHandler<GetProductCategoryByEncodedNameQuery, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryByEncodedNameQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ProductCategoryDto> Handle(GetProductCategoryByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<ProductCategoryDto>(productCategory);
            return dto;
        }
    }
}
