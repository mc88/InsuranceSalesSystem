using System.Collections.Generic;

namespace PricingService.Api.Dto
{
    public class PricingRequestDto
    {
        public string ProductCode { get; set; }

        public PersonDto PolicyHolder { get; set; }

        public IList<string> SelectedCovers { get; set; }
    }
}
