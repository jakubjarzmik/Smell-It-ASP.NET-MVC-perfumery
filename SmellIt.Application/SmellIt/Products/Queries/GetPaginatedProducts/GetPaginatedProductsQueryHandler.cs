using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.SmellIt.Products.Queries.GetPaginatedProducts;
public class GetPaginatedProductsQueryHandler : IRequestHandler<GetPaginatedProductsQuery, ProductsViewModel>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetPaginatedProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductsViewModel> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetAll();
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        
        var paginatedProducts = productDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)productDtos.Count() / request.PageSize);
        
        var viewModel = new ProductsViewModel
        {
            Items = paginatedProducts,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
