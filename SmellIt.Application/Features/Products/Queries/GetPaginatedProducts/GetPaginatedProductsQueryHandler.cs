using AutoMapper;
using MediatR;
using SmellIt.Application.Features.Products.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.Products.Queries.GetPaginatedProducts;
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
        var totalProducts = await _productRepository.CountAsync();
        var products = await _productRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

        var viewModel = new ProductsViewModel(productDtos, totalProducts, request.PageNumber, request.PageSize);

        return viewModel;
    }
}
