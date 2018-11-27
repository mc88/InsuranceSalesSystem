using System;

namespace PaymentService.Bo.Integration.Events
{
    public class PolicyCreatedEvent : IIntegrationEvent
    {
        public string PolicyNumber { get; set; }

        public decimal Price { get; set; }

        public DateTime PolicyStartDate { get; set; }
    }
}
