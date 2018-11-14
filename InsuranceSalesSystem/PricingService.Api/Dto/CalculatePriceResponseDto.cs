using System.Collections.Generic;

namespace PricingService.Api.Dto
{
    public class CalculatePriceResponseDto
    {
        public string ProductCode { get; set; }

        public decimal TotalPrice { get; set; }

        public Dictionary<string, decimal> CoverPrices { get; set; }
    }
}
