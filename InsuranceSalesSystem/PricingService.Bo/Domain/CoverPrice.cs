namespace PricingService.Bo.Domain
{
    public class CoverPrice : BaseEntity
    {
        public string Code { get; set; }

        public int AgeFrom { get; set; }

        public int AgeTo { get; set; }

        public decimal Price { get; set; }

        public int TariffVersionId { get; set; }
    }
}
