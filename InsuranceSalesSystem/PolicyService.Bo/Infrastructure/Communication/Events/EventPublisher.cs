using Newtonsoft.Json;
using PolicyService.Api.Dto.Events;
using RabbitMQ.Client;
using System;
using System.Text;

namespace PolicyService.Bo.Infrastructure.Communication.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IConnectionFactory connectionFactory;

        public EventPublisher(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Publish(IIntegrationEvent @event)
        {
            //TODO: move "magic strings" to configuration

            IConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "iss-exchange", type: "direct");


                channel.BasicPublish(exchange: "iss-exchange",
                                                 routingKey: @event.GetType().Name,
                                                 basicProperties: null,
                                                 body: PrepareMessage(@event));
            }
        }

        private byte[] PrepareMessage(IIntegrationEvent @event)
        {
            var message = JsonConvert.SerializeObject(@event);
            return Encoding.UTF8.GetBytes(message);
        }
    }
}
