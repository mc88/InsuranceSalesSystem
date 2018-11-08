namespace PricingService.Bo.Domain
{
    public class CoverPrice
    {
        public string Code { get; set; }

        public int AgeFrom { get; set; }

        public int AgeTo { get; set; }

        public decimal Price { get; set; }
    }
}
