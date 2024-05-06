using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Marten;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.DeleteProduct;

internal sealed class DeleteProductCommandHandler(
    IDocumentSession session,
    ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
