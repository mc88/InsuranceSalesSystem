using ISSMobile.Enums;
using Plugin.Iconize;
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

        public string IconName
        {
            get
            {
                string icon;

                switch (OfferStatus)
                {
                    case OfferStatus.Active:
                        {
                            icon = Iconize.FindIconForKey("fas-home").Key;
                            //icon = Iconize.FindIconForKey("far fa-grin").Key;
                            break;
                        }
                    case OfferStatus.Expired:
                        {
                            icon = Iconize.FindIconForKey("fas-road").Key;
                            //icon = Iconize.FindIconForKey("fa-frown").Key;
                            break;
                        }
                    case OfferStatus.Sold:
                        {                            
                            icon = Iconize.FindIconForKey("fas-home").Key;
                            //icon = Iconize.FindIconForKey("smile-wink").Key;
                            break;
                        }
                    default:
                        {
                            icon = Iconize.FindIconForKey("far fa-meh-blank").Key;
                            break;
                        }
                }

                return icon;
            }
        }
    }
}
