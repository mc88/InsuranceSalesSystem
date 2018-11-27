using MediatR;
using Newtonsoft.Json;
using PaymentService.Bo.Integration.Events;
using PaymentService.Bo.Integration.Handlers;
using System;

namespace PaymentService.Bo.Integration
{
    //TODO: find better way to this, try to use dotnet core IoC and resolve handlers in Startup.cs
    public class IntegrationEventHandlerFactory
    {
        private readonly IMediator mediator;

        public IntegrationEventHandlerFactory(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IIntegrationEventHandler CreateHandler(EventsToListenEnum @event, string message)
        {
            switch (@event)
            {
                case EventsToListenEnum.PolicyCreatedEvent:
                    var eventObject = JsonConvert.DeserializeObject<PolicyCreatedEvent>(message);
                    return new PolicyCreatedHandler(eventObject, mediator);
                default:
                    throw new ArgumentException($"Event: '{nameof(@event)}' cannot be handled");
            }
        }
    }
}
