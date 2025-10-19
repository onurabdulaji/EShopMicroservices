namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketCommandResponse>;
    public record DeleteBasketCommandResponse(bool IsSuccess);
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }
    public class DeleteBasketCommandHandler
        (IBasketRepository repository)
        : ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResponse>
    {
        public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            await repository.DeleteBasket(command.UserName ,cancellationToken);

            return new DeleteBasketCommandResponse(true);
        }   
    }
}
