using BuildingBlocks.CQRS;

namespace Catalog.Application.Products.GetProducts;

public record GetProductsQuery(GetProductsRequest Request) : IQuery<GetProductsResponse>;