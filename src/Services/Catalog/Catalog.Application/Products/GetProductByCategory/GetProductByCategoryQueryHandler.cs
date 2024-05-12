using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Marten;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.GetProductByCategory;

internal sealed class GetProductByCategoryQueryHandler(
    IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResponse>
{
    public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResponse(products);
    }
}
