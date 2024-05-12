using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Mapster;
using Marten;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.CreateProduct;
internal sealed class CreateProductComandHandler(
    IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        _ = command ?? throw new ArgumentNullException(nameof(command));

        var product = command.Adapt<Product>();
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse(product.Id);
    }
}
