using System;

namespace PolicyService.Api.Exceptions
{
    public class PolicyVersionNotFoundException : Exception
    {
        public string PolicyNumber { get; set; }
        public DateTime Date { get; set; }

        public PolicyVersionNotFoundException(string policyNumber, DateTime date)
        {
            PolicyNumber = policyNumber;
            Date = date;
        }

        public override string Message
        {
            get
            {
                return $"Policy Version for date '{Date.ToShortDateString()}' for policy '{PolicyNumber}' not found";
            }
        }
    }
}
