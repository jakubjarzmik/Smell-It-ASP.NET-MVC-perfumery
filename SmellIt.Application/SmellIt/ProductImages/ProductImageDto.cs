namespace SmellIt.Application.SmellIt.ProductImages;
public class ProductImageDto
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = default!;
    public string ImageAlt { get; set; } = default!;
}
