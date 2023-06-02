namespace SmellIt.Application.Features.ProductCategories.DTOs;
public class ProductCategoryDtoForWebsite
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public ProductCategoryDtoForWebsite? ParentCategory { get; set; }
}
