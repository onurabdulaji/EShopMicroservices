using BuildingBlocks.CQRS;
using FluentValidation;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;
    public record CreateOrderResult(Guid Id);
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(q => q.Order.OrderName).NotEmpty().WithMessage("Name is Requried!"); 
            RuleFor(q => q.Order.CustomerId).NotNull().WithMessage("Customer ID is Requried!"); 
            RuleFor(q => q.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not be Empty!"); 
        }
    }
}

