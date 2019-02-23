using System;
using System.Collections.Generic;
using System.Text;

namespace ISSMobile.Model
{
    public class CreateOffer
    {
        private string cover;

        public CreateOffer()
        {
            PolicyHolder = new Person();
        }

        public string ProductCode { get; set; }

        public Person PolicyHolder { get; set; }

        public string Cover
        {
            get { return cover; }
            set
            {
                cover = value;
                SelectedCovers = new List<string> { cover };
            }
        }

        public IList<string> SelectedCovers { get; set; }

        public DateTime PolicyFrom { get; set; }

        public DateTime PolicyTo { get; set; }
    }
}
