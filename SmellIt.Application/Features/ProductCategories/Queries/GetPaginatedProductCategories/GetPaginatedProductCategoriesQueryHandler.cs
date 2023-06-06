using AutoMapper;
using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Application.ViewModels.Admin;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetPaginatedProductCategories;
public class GetPaginatedProductCategoriesQueryHandler : IRequestHandler<GetPaginatedProductCategoriesQuery, ProductCategoriesViewModel>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetPaginatedProductCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }
    public async Task<ProductCategoriesViewModel> Handle(GetPaginatedProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var totalProductCategories = await _productCategoryRepository.CountAsync();
        var productCategories = await _productCategoryRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);

        var productCategoryDtos = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);

        var viewModel = new ProductCategoriesViewModel(productCategoryDtos, totalProductCategories, request.PageNumber, request.PageSize);

        return viewModel;
    }

}
