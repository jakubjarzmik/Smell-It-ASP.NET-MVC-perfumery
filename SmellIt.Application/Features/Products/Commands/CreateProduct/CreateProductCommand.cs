using MediatR;
using Microsoft.AspNetCore.Http;
using SmellIt.Application.Features.Products.DTOs;

namespace SmellIt.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : ProductDto, IRequest
{
    public decimal PriceValue { get; set; }
    public decimal? PromotionalPriceValue { get; set; }
    public List<IFormFile>? ImageFiles { get; set; }
}