using PolicyService.Api.Dto;
using PolicyService.Bo.Domain;

namespace PolicyService.Bo.Mappers
{
    public static class PolicyVersionMapper
    {
        public static PolicyVersionDto MapPolicyVersionToPolicyVersionDto(PolicyVersion policyVersion)
        {
            return new PolicyVersionDto()
            {
                PolicyNumber = policyVersion.PolicyNumber,
                PolicyHolder = PolicyHolderMapper.MapPolicyHolderToPersonDto(policyVersion.PolicyHolder),
                PolicyFrom = policyVersion.PolicyFrom,
                PolicyStatus = policyVersion.PolicyStatus,
                PolicyTo = policyVersion.PolicyTo,
                ProductCode = policyVersion.ProductCode,
                TotalPremium = policyVersion.TotalPremium,
                VersionFrom = policyVersion.VersionFrom,
                VersionNumber = policyVersion.VersionNumber,
                VersionTo = policyVersion.VersionTo
            };
        }
    }
}
