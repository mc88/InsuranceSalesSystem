using System;

namespace PolicyService.Bo.Domain
{
    public class PolicyCover : BaseEntity
    {
        public PolicyCover() { }

        public PolicyCover(OfferCover offerCover)
        {
            CoverCode = offerCover.CoverCode;
            CoverFrom = offerCover.CoverFrom;
            CoverTo = offerCover.CoverTo;
            Price = offerCover.Price;
        }

        public string CoverCode { get; set; }

        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public decimal Price { get; set; }
    }
}
