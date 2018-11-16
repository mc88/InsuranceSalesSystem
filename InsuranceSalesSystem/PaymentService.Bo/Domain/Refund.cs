using System;

namespace PaymentService.Bo.Domain
{
    public class Refund : AccountOperation
    {
        public Refund(decimal amount, DateTime effectiveDate) : base(amount, effectiveDate) { }
    }
}
