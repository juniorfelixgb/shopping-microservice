using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResponse>;
