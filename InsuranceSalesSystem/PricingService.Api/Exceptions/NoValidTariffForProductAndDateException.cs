using System;

namespace PricingService.Api.Exceptions
{
    public class NoValidTariffForProductAndDateException : Exception
    {
        public string ProductCode { get; set; }
        public DateTime CoverDate { get; set; }

        public NoValidTariffForProductAndDateException(string productCode, DateTime coverDate)
        {
            ProductCode = productCode;
            CoverDate = coverDate;
        }

        public override string Message
        {
            get
            {
                return $"There is no valid tariff for product '{ProductCode}' and cover date '{CoverDate.ToShortDateString()}'";
            }
        }
    }
}
