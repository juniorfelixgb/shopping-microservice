using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Marten;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.GetProducts;

internal sealed class GetProductsQueryHandler(
    IDocumentSession session,
    ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

        var products = await session
            .Query<Product>()
            .ToListAsync(cancellationToken);

        return new GetProductsResponse(products);
    }
}
