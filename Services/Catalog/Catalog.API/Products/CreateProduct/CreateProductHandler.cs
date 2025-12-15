using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler
    : ICommadHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken)
    {

        var product = new Product
        {
            Category = command.Category,
            Description = command.Description,
            Name = command.Name,
            Price = command.Price
        };

        return new CreateProductResult(product.Id);
    }
}