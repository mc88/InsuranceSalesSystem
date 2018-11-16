using System;

namespace PaymentService.Bo.Domain
{
    public class ExpectedPayment : AccountOperation
    {
        public ExpectedPayment(decimal amount, DateTime effectiveDate) : base(amount, effectiveDate) { }
    }
}
