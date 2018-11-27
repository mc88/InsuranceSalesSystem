using MediatR;

namespace PaymentService.Bo.Integration
{
    public abstract class BaseIntegrationEventHandler<T> : IIntegrationEventHandler where T : IIntegrationEvent 
    {
        protected readonly T @event;
        protected readonly IMediator mediator;

        public BaseIntegrationEventHandler(T @event, IMediator mediator)
        {
            this.@event = @event;
            this.mediator = mediator;
        }

        public abstract void Handle();
    }
}
