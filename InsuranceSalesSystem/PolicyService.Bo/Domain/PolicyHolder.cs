using PolicyService.Api.Dto;

namespace PolicyService.Bo.Domain
{
    public class PolicyHolder : BaseEntity
    {
        public PolicyHolder() { }

        public PolicyHolder(PersonDto request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Pesel = request.Pesel;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }
    }
}
