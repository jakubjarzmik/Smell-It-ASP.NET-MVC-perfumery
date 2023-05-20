namespace SmellIt.Application.SmellIt.ProductCategories;
public class WebsiteProductCategoryDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public WebsiteProductCategoryDto? ParentCategory { get; set; }
}
