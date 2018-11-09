using System;

namespace PricingService.Api.Exceptions
{
    public class NoPriceForGivenAgeException : Exception
    {
        public int Age { get; set; }

        public NoPriceForGivenAgeException(int age)
        {
            Age = age;
        }

        public override string Message
        {
            get
            {
                return $"There is no defined price for age '{Age}'";
            }
        }
    }
}
