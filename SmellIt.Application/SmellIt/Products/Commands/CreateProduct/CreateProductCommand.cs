using MediatR;
using Microsoft.AspNetCore.Http;

namespace SmellIt.Application.SmellIt.Products.Commands.CreateProduct
{
    public class CreateProductCommand : ProductDto, IRequest
    {
        public string? ProductCategoryEncodedName { get; set; }
        public string? BrandEncodedName { get; set; }
        public string? FragranceCategoryEncodedName { get; set; }
        public int? GenderId { get; set; }
        public decimal PriceValue { get; set; }
        public DateTime PriceStartDateTime { get; set; }
        public DateTime? PriceEndDateTime { get; set; }
        public decimal? PromotionalPriceValue { get; set; }
        public DateTime PromotionalPriceStartDateTime { get; set; }
        public DateTime? PromotionalPriceEndDateTime { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
