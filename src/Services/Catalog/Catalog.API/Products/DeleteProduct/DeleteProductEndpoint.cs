
using Catalog.API.Products.DeleteProduct;

namespace Catalog.API.Products.DeleteProduct
{
    //public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("products/{id}" , async (Guid id , ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));

                var response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
                .WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Delete a product")
                .WithDescription("Deletes a product by its id.");
        }
    }
}

//// Varsayımsal ve gereksiz DTO kullanımı:
//app.MapDelete("products", async (DeleteProductRequest request, ISender sender) =>
//{
//    // 1. Request Body'den ID'yi al. (Body'de ID almak RESTful değildir!)
//    // 2. Request'i Command'a Mapster ile dönüştür. (Gereksiz Mapster çağrısı)
//    var command = request.Adapt<DeleteProductCommand>();
//    // ...
//});

//Kod Tekrarından Kaçınma (DRY Prensibi)
//DeleteProductRequest tanımında yalnızca Guid Id olacağı için, zaten Command nesnesi (DeleteProductCommand(Guid Id)) aynı işi yapmaktadır.

//Ayrı bir Request DTO kullanmak, sadece DTO, Mapster konfigürasyonu ve Mapster çağrısı eklemekten başka bir işe yaramazdı.

//Sonuç
//Delete işleminde DTO kullanmamanız, daha iyi bir tasarım kararıdır:

//Daha Az Kod: Fazladan DTO tanımı ve Adapt çağrısı atlanmıştır.

//Daha Saf REST: ID'yi URL'de taşıyarak endüstri standardı RESTful kuralına uyulmuştur.

//Verimlilik: Rotadaki veriyi doğrudan Command'ı oluşturmak için kullanmak en verimli yoldur.

//Bu, kodunuzun sade ve işlevsel olduğunu gösterir.
