using System;

namespace PolicyService.Bo.Domain
{
    public class OfferCover : BaseEntity
    {
        public OfferCover() { }

        public OfferCover(string code, DateTime from, DateTime to, decimal price)
        {
            CoverCode = code;
            CoverFrom = from;
            CoverTo = to;
            Price = price;
        }

        public string CoverCode { get; set; }

        public DateTime CoverFrom { get; set; }

        public DateTime CoverTo { get; set; }

        public decimal Price { get; set; }
    }
}
