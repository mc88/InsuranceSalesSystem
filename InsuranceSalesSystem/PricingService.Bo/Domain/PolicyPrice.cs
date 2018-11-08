using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class PolicyPrice : BaseEntity
    {
        public string ProductCode { get; set; }

        public virtual PolicyHolder PolicyHolder { get; set; }

        public virtual IList<CoverPrice> SelectedCovers { get; set; }
    }
}
