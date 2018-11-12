using PolicyService.Api.Enums;
using System;
using System.Collections.Generic;

namespace PolicyService.Bo.Domain
{
    public class Offer : BaseEntity
    {
        public string OfferNumber { get; set; }

        public string ProductCode { get; set; }

        public PolicyHolder PolicyHolder { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IList<OfferCover> Covers { get; set; }
    }
}
