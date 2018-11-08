using System;

namespace PricingService.Bo.Domain
{
    public class PolicyHolder : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }

        public int CalculateAge()
        {
            //TODO: calculate age basing on pesel
            throw new NotImplementedException();
        }
    }
}
