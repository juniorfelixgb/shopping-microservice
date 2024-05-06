using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id, UpdateProductRequest UpdateProduct) : ICommand<UpdateProductResponse>;
