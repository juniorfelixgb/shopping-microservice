using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResponse>;
