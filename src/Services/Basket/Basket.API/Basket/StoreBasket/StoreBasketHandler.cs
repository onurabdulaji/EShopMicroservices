namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(q=>q.Cart).NotNull().WithMessage("Cart cannot be null");
            RuleFor(q=>q.Cart.UserName).NotEmpty().WithMessage("UserName cannot be empty");
        }
    }
    public class StoreBasketCommandHandler
        (IBasketRepository repository)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            // Communicate With gRPC For Discount Service To Retrieve Discounts For Each Item In The Cart

            ShoppingCart cart = command.Cart;

            await repository.StoreBasket(command.Cart , cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
