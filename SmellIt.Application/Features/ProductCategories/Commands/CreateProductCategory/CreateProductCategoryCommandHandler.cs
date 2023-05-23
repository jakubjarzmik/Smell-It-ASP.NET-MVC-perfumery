using AutoMapper;
using MediatR;
using SmellIt.Domain.Entities;
using SmellIt.Domain.Interfaces;

namespace SmellIt.Application.Features.ProductCategories.Commands.CreateProductCategory;
public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand>
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;
    public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
    {
        _productCategoryRepository = productCategoryRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(request.ParentCategoryEncodedName))
        {
            var parentCategory = await _productCategoryRepository.GetByEncodedName(request.ParentCategoryEncodedName!);
            request.ParentCategory = _mapper.Map<ProductCategoryDto>(parentCategory);
        }

        var productCategory = _mapper.Map<ProductCategory>(request);
        await _productCategoryRepository.Create(productCategory);
        return Unit.Value;
    }
}