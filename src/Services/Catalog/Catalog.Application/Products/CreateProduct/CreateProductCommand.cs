using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResponse>;
