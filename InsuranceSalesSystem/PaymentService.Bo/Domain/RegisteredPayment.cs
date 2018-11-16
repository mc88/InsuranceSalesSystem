using System;

namespace PaymentService.Bo.Domain
{
    public class RegisteredPayment : AccountOperation
    {
        public RegisteredPayment(decimal amount, DateTime effectiveDate) : base(amount, effectiveDate) { }
    }
}
