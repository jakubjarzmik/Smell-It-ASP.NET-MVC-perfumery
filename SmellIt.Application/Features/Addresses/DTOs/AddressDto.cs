namespace SmellIt.Application.Features.Addresses.DTOs;

public class AddressDto
{
    public string FullName { get; set; } = default!;
    public string FirstLine { get; set; } = default!;
    public string? SecondLine { get; set; }
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
}