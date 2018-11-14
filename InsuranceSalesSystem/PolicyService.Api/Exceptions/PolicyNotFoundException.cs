using System;

namespace PolicyService.Api.Exceptions
{
    public class PolicyNotFoundException : Exception
    {
        public string PolicyNumber { get; set; }

        public PolicyNotFoundException(string policyNumber)
        {
            PolicyNumber = policyNumber;
        }

        public override string Message
        {
            get
            {
                return $"Policy with number '{PolicyNumber}' not found";
            }
        }
    }
}
