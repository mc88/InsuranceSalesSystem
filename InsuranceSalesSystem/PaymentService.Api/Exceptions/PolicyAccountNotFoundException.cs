using System;

namespace PaymentService.Api.Exceptions
{
    public class PolicyAccountNotFoundException : Exception
    {
        public string PolicyNumber { get; set; }

        public PolicyAccountNotFoundException(string policyNumber)
        {
            PolicyNumber = policyNumber;
        }

        public override string Message
        {
            get
            {
                return $"Account for policy with number '{PolicyNumber}' not found";
            }
        }
    }
}
