using Microsoft.Extensions.DependencyInjection;
using PaymentService.Bo.Integration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace PaymentService.Web.Listeners
{
    public class RabbitMqListener
    {
        private readonly string[] EVENTS_TO_LISTEN = 
        {
            "PolicyCreatedEvent"
        };

        private readonly IServiceProvider serviceProvider;

        public RabbitMqListener(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Listen()
        {
            //TODO: move "magic strings" to configuration

            using (var scope = serviceProvider.CreateScope())
            {
                var factory = scope.ServiceProvider.GetRequiredService<IConnectionFactory>();

                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();

                channel.ExchangeDeclare(exchange: "iss-exchange", type: "direct");
                var queueName = channel.QueueDeclare("iss-payment-queue", true, false, false).QueueName;


                foreach (var @event in Enum.GetNames(typeof(EventsToListenEnum)))
                {
                    channel.QueueBind(queue: queueName,
                                      exchange: "iss-exchange",
                                      routingKey: @event);
                }

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) => OnMessageReceived(model, ea);

                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

            }

            //TODO: when not using 'using' for connection and channel it must be disposed somewhere
            
        }

        private void OnMessageReceived(object model, BasicDeliverEventArgs ea)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;

                EventsToListenEnum enumValue;

                bool isRoutingKeyValid = Enum.TryParse(routingKey, out enumValue);

                if (!isRoutingKeyValid)
                {
                    //TODO 
                }

                var handlerFactory = scope.ServiceProvider.GetRequiredService<IntegrationEventHandlerFactory>();

                var handler = handlerFactory.CreateHandler(enumValue, message);
                handler.Handle();
            }
        }
    }
}
