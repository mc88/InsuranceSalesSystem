namespace PricingService.Bo.Domain
{
    public class PolicyPrice : BaseEntity
    {
        public string ProductCode { get; set; }

        public int PolicyHolderId { get; set; }

        public virtual PolicyHolder PolicyHolder { get; set; }
    }
}
