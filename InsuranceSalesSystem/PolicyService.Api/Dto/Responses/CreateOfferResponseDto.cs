using System;

namespace PolicyService.Api.Dto.Responses
{
    public class CreateOfferResponseDto
    {
        public string OfferNumber { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OfferValidityEnd { get; set; }
    }
}
