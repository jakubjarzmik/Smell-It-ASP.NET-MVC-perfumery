namespace SmellIt.Application.Features.FragranceCategories.DTOs;
public class WebsiteFragranceCategoryDto
{
    public string EncodedName { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
