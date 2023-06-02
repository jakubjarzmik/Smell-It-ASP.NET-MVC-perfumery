using MediatR;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Commands.EditProduct;

public class EditProductCommand : ProductDto, IRequest
{
    public decimal PriceValue { get; set; }
    public DateTime PriceStartDateTime { get; set; }
    public DateTime? PriceEndDateTime { get; set; }
    public decimal? PromotionalPriceValue { get; set; }
    public DateTime? PromotionalPriceStartDateTime { get; set; }
    public DateTime? PromotionalPriceEndDateTime { get; set; }
}