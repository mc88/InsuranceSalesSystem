using System;

namespace PaymentService.Api.Dto
{
    public class BankStatementDto
    {
        public string PolicyNumber { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
