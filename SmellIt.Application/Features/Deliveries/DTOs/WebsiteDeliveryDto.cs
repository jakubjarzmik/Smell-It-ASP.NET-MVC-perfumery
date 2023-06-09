﻿namespace SmellIt.Application.Features.Deliveries.DTOs;
public class WebsiteDeliveryDto
{
    public int Id { get; set; } = default!;
    public string EncodedName { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
