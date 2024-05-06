using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Mapster;
using Marten;

namespace Catalog.Application.Products.CreateProduct;
internal sealed class CreateProductComandHandler(
    IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResponse>
{
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResponse(product.Id);
    }
}
