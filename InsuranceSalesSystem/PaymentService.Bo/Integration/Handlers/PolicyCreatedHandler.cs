using MediatR;
using PaymentService.Api.Dto.Requests;
using PaymentService.Bo.Integration.Events;
using System;

namespace PaymentService.Bo.Integration.Handlers
{
    public class PolicyCreatedHandler : BaseIntegrationEventHandler<PolicyCreatedEvent>
    {
        public PolicyCreatedHandler(PolicyCreatedEvent @event, IMediator mediator) : base(@event, mediator) { }

        public override void Handle()
        {
            var request = new CreateAccountForPolicyRequestDto()
            {
                PolicyNumber = @event.PolicyNumber,
                PolicyStartDate = @event.PolicyStartDate,
                Price = @event.Price
            };

            mediator.Send(request);
        }
    }
}
