namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand( string Name , List<string> Category, string Description , string ImageFile , decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Bussiness Logic To Create Product
            // Create Product Entity From Command Object
            // Save To Database
            // Return CreateProductResult Created Product Id

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };


            // save to db

            session.Store(product);

            await session.SaveChangesAsync(cancellationToken);

            // retun result

            return new CreateProductResult(product.Id);
                
        }
    }
}
