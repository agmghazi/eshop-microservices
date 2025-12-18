
namespace Catalog.API.Products.CreateProduct;

public record CreateProductRequest(string Name, List<string> Category, string Description, decimal Price);
public record CreateProductResponse(Guid id);
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
           async (CreateProductRequest requset, ISender sender) =>
           {
               var command = requset.Adapt<CreateProductCommand>();
               var result = await sender.Send(command);
               var respnse = result.Adapt<CreateProductResponse>();
               return Results.Created($"/products/{respnse.id}", respnse);
           })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Creates a new product")
            .WithDescription("Creates a new product with the provided details.");
    }
}
