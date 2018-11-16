using System;

namespace PaymentService.Api.Exceptions
{
    public class PolicyAccountAlreadyExists : Exception
    {
        public string PolicyNumber { get; set; }

        public PolicyAccountAlreadyExists(string policyNumber)
        {
            PolicyNumber = policyNumber;
        }

        public override string Message
        {
            get
            {
                return $"Account for policy with number '{PolicyNumber}' already exists.";
            }
        }
    }
}
