using AutoMapper;
using MediatR;
using SmellIt.Application.ViewModels;
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
        var productCategories = await _productCategoryRepository.GetAll();
        var productCategoryDtos = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);
        
        var paginatedProductCategories = productCategoryDtos
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var totalPages = (int)Math.Ceiling((double)productCategoryDtos.Count() / request.PageSize);
        
        var viewModel = new ProductCategoriesViewModel
        {
            Items = paginatedProductCategories,
            CurrentPage = request.PageNumber,
            TotalPages = totalPages,
            PageSize = request.PageSize
        };

        return viewModel;
    }
}
