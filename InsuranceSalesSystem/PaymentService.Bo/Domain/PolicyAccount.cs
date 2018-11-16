using PaymentService.Api.Dto;
using PaymentService.Api.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentService.Bo.Domain
{
    public class PolicyAccount : BaseEntity
    {
        public PolicyAccount() { }

        public PolicyAccount(CreateAccountForPolicyRequestDto request)
        {
            PolicyNumber = request.PolicyNumber;
            AccountOperations = new List<AccountOperation>() { new ExpectedPayment(request.Price, request.PolicyStartDate) };
        }

        public string PolicyNumber { get; set; }

        public IList<AccountOperation> AccountOperations { get; set; }

        public decimal BalanceAt(DateTime date)
        {
            var accountOperationsAt = AccountOperations.Where(x => x.EffectiveDate <= date);

            var registeredPaymentsAmount = accountOperationsAt.Where(x => x is RegisteredPayment).Sum(x => x.Amount);
            var expectedPaymentsAmount = accountOperationsAt.Where(x => x is ExpectedPayment).Sum(x => x.Amount);
            var refundsAmount = accountOperationsAt.Where(x => x is Refund).Sum(x => x.Amount);

            decimal balance = 0;

            balance -= expectedPaymentsAmount;
            balance += registeredPaymentsAmount;
            balance -= refundsAmount;

            return balance;
        }

        public void Apply(BankStatementDto bankStatement)
        {
            if (bankStatement.Amount < 0)
            {
                var refund = new Refund(Math.Abs(bankStatement.Amount), bankStatement.Date);
                AccountOperations.Add(refund);
            }
            else
            {
                var registeredPayment = new RegisteredPayment(bankStatement.Amount, bankStatement.Date);
                AccountOperations.Add(registeredPayment);
            }
        }
    }
}
