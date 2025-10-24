using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            // Create Order Entity from Command Object
            // Save To Db
            // Return Result
            throw new NotImplementedException();
        }
    }
}
