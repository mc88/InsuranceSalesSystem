using System;

namespace PolicyService.Bo.Domain
{
    public class OfferCover : BaseEntity
    {
        public string CoverCode { get; set; }

        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public decimal Price { get; set; }
    }
}
