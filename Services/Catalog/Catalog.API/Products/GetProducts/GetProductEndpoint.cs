namespace Catalog.API.Products.GetProducts
{
    public record GetProductRequest(IEnumerable<Product> Products);
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetProducts",
               async (ISender sender) =>
               {
                   var query = new GetProductsQuery();
                   var result = await sender.Send(query);
                   var response = result.Adapt<GetProductRequest>();
                   return Results.Ok(response);
               })
             .WithName("GetProducts")
             .Produces<GetProductRequest>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Gets all products")
             .WithDescription("Retrieves a list of all products available in the catalog.");
        }
    }
}
