using System;
using System.Collections.Generic;

namespace PolicyService.Api.Dto.Pricing.Requests
{
    //TODO: this is copy of CalculatePriceRequestDto class from PricingService - is it should be done like that?
    public class CalculatePriceRequestDto
    {
        public string ProductCode { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public int PolicyHolderAge { get; set; }

        public IList<string> SelectedCovers { get; set; }
    }
}
