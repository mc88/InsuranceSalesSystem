using System;

namespace PricingService.Api.Exceptions
{
    public class NoPriceForGivenAgeException : Exception
    {
        public string CoverCode { get; set; }
        public int Age { get; set; }

        public NoPriceForGivenAgeException(string coverCode, int age)
        {
            CoverCode = coverCode;
            Age = age;
        }

        public override string Message
        {
            get
            {
                return $"There is no defined price for cover '{CoverCode}' and age '{Age}'";
            }
        }
    }
}
