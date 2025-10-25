using MassTransit;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler
        (ILogger<OrderCreatedEventHandler> logger , IPublishEndpoint publishEndpoint)
        : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event Handled : {DomainEvent}", domainEvent.GetType().Name);

            var orderCratedIntegrationEvet = domainEvent.Order.ToOrderDto();

            await publishEndpoint.Publish(orderCratedIntegrationEvet, cancellationToken);
        }
    }
}
