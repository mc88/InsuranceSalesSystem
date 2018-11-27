using PolicyService.Api.Dto.Events;

namespace PolicyService.Bo.Infrastructure.Communication.Events
{
    public interface IEventPublisher
    {
        void Publish(IIntegrationEvent @event);
    }
}
