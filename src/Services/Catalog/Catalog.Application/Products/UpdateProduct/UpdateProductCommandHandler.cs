﻿using BuildingBlocks.CQRS;
using Catalog.Domain.Entities;
using Catalog.Domain.Exceptions;
using Marten;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler(
    IDocumentSession session,
    ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
{
    public async Task<UpdateProductResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.Id.ToString());
        }

        product.Name = command.UpdateProduct.Name;
        product.Description = command.UpdateProduct.Description;
        product.Price = command.UpdateProduct.Price;
        product.Category = command.UpdateProduct.Category;
        product.ImageFile = command.UpdateProduct.ImageFile;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResponse(true);
    }
}
