using System;
using System.Collections.Generic;

namespace PolicyService.Api.Dto
{
    public class CreateOfferRequestDto
    {
        public string ProductCode { get; set; }

        public PersonDto PolicyHolder { get; set; }

        public IList<string> SelectedCovers { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }
    }
}
