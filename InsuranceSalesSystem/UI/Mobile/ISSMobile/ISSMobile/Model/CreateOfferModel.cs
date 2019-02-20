using System;
using System.Collections.Generic;

namespace ISSMobile.Model
{
    public class CreateOfferModel
    {
        public CreateOfferModel()
        {
            PolicyHolder = new PersonModel();
        }

        public string ProductCode { get; set; }

        public PersonModel PolicyHolder { get; set; }

        public IList<string> SelectedCovers { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }
    }
}
