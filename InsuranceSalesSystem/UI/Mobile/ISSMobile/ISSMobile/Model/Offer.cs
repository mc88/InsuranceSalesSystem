using ISSMobile.Enums;
using System;
using System.Collections.Generic;

namespace ISSMobile.Model
{
    public class Offer
    {
        public string OfferNumber { get; set; }

        public string ProductCode { get; set; }

        //public PersonDto PolicyHolder { get; set; }

        public OfferStatus OfferStatus { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }

        public IDictionary<string, decimal> Covers { get; set; }

        public override string ToString()
        {
            return $"No: {OfferNumber}";
        }

        public string StatusColor
        {
            get
            {
                string color;

                switch (OfferStatus)
                {
                    case OfferStatus.Active:
                        {
                            color = "Green";
                            break;
                        }
                    case OfferStatus.Expired:
                        {
                            color = "Red";
                            break;
                        }
                    case OfferStatus.Sold:
                        {
                            color = "Blue";
                            break;
                        }
                    default:
                        {
                            color = "Black";
                            break;
                        }
                }

                return color;
            }
        }
    }
}
