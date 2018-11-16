using System;

namespace PaymentService.Bo.Domain
{
    public abstract class AccountOperation : BaseEntity
    {
        public AccountOperation(decimal amount, DateTime effectiveDate)
        {
            Amount = amount;
            EffectiveDate = effectiveDate;
            RegistrationDate = DateTime.Now;
        }

        public DateTime EffectiveDate { get; set; }

        public decimal Amount { get; set; }

        public DateTime RegistrationDate { get; set; }

        public decimal Apply(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
