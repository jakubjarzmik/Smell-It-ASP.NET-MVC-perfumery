using AutoMapper;
using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Queries.GetAllProductCategoriesForWebsite;
public class GetAllProductCategoriesForWebsiteQueryHandler : IRequestHandler<GetAllProductCategoriesForWebsiteQuery, IEnumerable<WebsiteProductCategoryDto>>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllProductCategoriesForWebsiteQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<WebsiteProductCategoryDto>> Handle(GetAllProductCategoriesForWebsiteQuery request, CancellationToken cancellationToken)
    {
        var productCategories = await _productCategoryRepository.GetAllAsync();
        var dtos = _mapper.Map<IEnumerable<WebsiteProductCategoryDto>>(productCategories, opt =>
        {
            opt.Items["LanguageCode"] = request.LanguageCode;
        });
        return dtos;
    }
}
