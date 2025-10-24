namespace Ordering.API.Endpoints
{
    // Accept a CreateOrderRequest object.
    // Maps The request to a CreateOrderCommand.
    // Uses MediatR to send the command to the corresponding handler.
    // Return a response with created order's ID.
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid Id);
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateOrderCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);
            })
                .WithName("Create Order")
                .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
                .WithSummary("Create Order")
                .WithDescription("Create Order");
        }
    }
}


//Giriş Çevrimi(Mapping In): Gelen HTTP isteği (CreateOrderRequest),
//    Mapster'ın Adapt<CreateOrderCommand>() metodu kullanılarak hemen Application Katmanı'nın anladığı bir komuta çevrilir.

//Yönlendirme: ISender sender(MediatR) ile komut, Application katmanındaki ilgili Handler'a (CreateOrderHandler) gönderilir. API katmanı, iş mantığını bilmez.

//Çıkış Çevrimi(Mapping Out): Handler'dan gelen sonuç (CreateOrderResult), Mapster ile dış dünyaya uygun formata (CreateOrderResponse) çevrilir.