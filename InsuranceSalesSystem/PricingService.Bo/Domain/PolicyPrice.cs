using System.Collections.Generic;
using System.Linq;

namespace PricingService.Bo.Domain
{
    public class PolicyPrice
    {
        public PolicyPrice(string productCode, IList<CoverPrice> selectedCoverPrices)
        {
            ProductCode = productCode;
            SelectedCoverPrices = selectedCoverPrices;
        }

        public string ProductCode { get; set; }

        public IList<CoverPrice> SelectedCoverPrices { get; set; }

        public decimal TotalPrice => SelectedCoverPrices.Sum(x => x.Price);
    }
}
