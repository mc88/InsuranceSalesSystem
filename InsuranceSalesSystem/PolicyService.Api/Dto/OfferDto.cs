using PolicyService.Api.Enums;
using System;
using System.Collections.Generic;

namespace PolicyService.Api.Dto
{
    public class OfferDto
    {
        public string OfferNumber { get; set; }

        public string ProductCode { get; set; }

        public PersonDto PolicyHolder { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IDictionary<string, decimal> Covers { get; set; }
    }
}
