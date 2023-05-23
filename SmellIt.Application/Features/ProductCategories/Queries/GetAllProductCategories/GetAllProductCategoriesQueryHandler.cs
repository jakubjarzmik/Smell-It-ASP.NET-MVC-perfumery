using AutoMapper;
using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategories;
public class GetAllProductCategoriesQueryHandler : IRequestHandler<GetAllProductCategoriesQuery, IEnumerable<ProductCategoryDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllProductCategoriesQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductCategoryDto>> Handle(GetAllProductCategoriesQuery request, CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetAll();
        var dtos = _mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories);
        return dtos;
    }
}
