using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Products.Queries.GetFilteredProducts
{
    public class GetFilteredProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetFilteredProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetFilteredProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = new List<Product>();

            if (request.CategoryEncodedName != null)
                 products = await _productRepository.GetProductsByCategoryEncodedName(request.CategoryEncodedName);
            else
                products = await _productRepository.GetAll();

            if (request.BrandEncodedName != null)
                products = products.Where(p => p.Brand?.EncodedName == request.BrandEncodedName);
            if (request.FragranceCategoryEncodedName != null)
                products = products.Where(p => p.FragranceCategory?.EncodedName == request.FragranceCategoryEncodedName);
            if (request.GenderEncodedName != null)
                products = products.Where(p => p.Gender?.EncodedName == request.GenderEncodedName);

            var dtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return dtos;
        }
    }
}