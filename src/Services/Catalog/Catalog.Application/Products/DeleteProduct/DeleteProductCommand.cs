using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand;
