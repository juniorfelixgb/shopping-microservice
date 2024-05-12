using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Marten;
using Marten.Pagination;

namespace Catalog.Application.Products.GetProducts;

internal sealed class GetProductsQueryHandler(
    IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResponse>
{
    public async Task<GetProductsResponse> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session
            .Query<Product>()
            .ToPagedListAsync(query.Request.PageNo ?? 1, query.Request.PageSize ?? 10, cancellationToken);

        return new GetProductsResponse(products);
    }
}
