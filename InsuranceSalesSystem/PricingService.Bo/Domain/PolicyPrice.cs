using System.Collections.Generic;

namespace PricingService.Bo.Domain
{
    public class PolicyPrice
    {
        public string ProductCode { get; set; }

        public PolicyHolder PolicyHolder { get; set; }

        public IList<string> SelectedCovers { get; set; }
    }
}
