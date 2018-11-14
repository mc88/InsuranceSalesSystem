using System;

namespace PolicyService.Api.Exceptions
{
    public class OfferNotFoundException : Exception
    {
        public string OfferNumber { get; set; }

        public OfferNotFoundException(string offerNumber)
        {
            OfferNumber = offerNumber;
        }

        public override string Message
        {
            get
            {
                return $"Offer with number '{OfferNumber}' not found";
            }
        }
    }
}
