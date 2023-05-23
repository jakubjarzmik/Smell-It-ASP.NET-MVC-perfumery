namespace SmellIt.Application.Features.ProductPrices
{
    public class ProductPriceDto
    {
        public bool IsPromotion { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
