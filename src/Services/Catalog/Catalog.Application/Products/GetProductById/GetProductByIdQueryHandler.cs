using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Marten;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.GetProductById;

internal sealed class GetProductByIdQueryHandler(
    IDocumentSession session,
    ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
        {
            logger.LogInformation("Product with Id: {@productId} not found!", query.Id);
            throw new ProductNotFoundException(query.Id);
        }

        return new GetProductByIdResponse(product);
    }
}
