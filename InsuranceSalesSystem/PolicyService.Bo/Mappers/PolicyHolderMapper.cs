using PolicyService.Api.Dto;
using PolicyService.Bo.Domain;

namespace PolicyService.Bo.Mappers
{
    public static class PolicyHolderMapper
    {
        public static PersonDto MapPolicyHolderToPersonDto(PolicyHolder policyHolder)
        {
            return new PersonDto()
            {
                FirstName = policyHolder.FirstName,
                LastName = policyHolder.LastName,
                Pesel = policyHolder.Pesel
            };
        }
    }
}
