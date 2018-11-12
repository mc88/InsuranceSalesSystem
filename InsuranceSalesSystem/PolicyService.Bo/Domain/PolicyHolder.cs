namespace PolicyService.Bo.Domain
{
    public class PolicyHolder : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }
    }
}
