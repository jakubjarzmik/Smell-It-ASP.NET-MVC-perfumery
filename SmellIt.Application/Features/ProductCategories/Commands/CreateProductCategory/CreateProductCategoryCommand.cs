using MediatR;
using SmellIt.Application.Features.ProductCategories.DTOs;

namespace SmellIt.Application.Features.ProductCategories.Commands.CreateProductCategory;

public class CreateProductCategoryCommand : ProductCategoryDto, IRequest
{
    public string? ParentCategoryEncodedName { get; set; }
}