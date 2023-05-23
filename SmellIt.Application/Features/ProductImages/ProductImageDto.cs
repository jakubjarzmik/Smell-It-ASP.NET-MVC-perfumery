namespace SmellIt.Application.Features.ProductImages;
public class ProductImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = default!;
    public string ImageAlt { get; set; } = default!;
}
