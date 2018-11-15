using System.Collections.Generic;

namespace PolicyService.Api.Dto.Pricing.Responses
{
    //TODO: this is copy of CalculatePriceResponseDto class from PricingService - is it should be done like that?
    public class CalculatePriceResponseDto
    {
        public string ProductCode { get; set; }

        public decimal TotalPrice { get; set; }

        public Dictionary<string, decimal> CoverPrices { get; set; }
    }
}
