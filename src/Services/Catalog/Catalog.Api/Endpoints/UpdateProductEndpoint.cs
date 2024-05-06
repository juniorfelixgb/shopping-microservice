using Carter;
using Catalog.Application.Products.UpdateProduct;
using MediatR;

namespace Catalog.Api.Endpoints;

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{id}", async (
            Guid id,
            UpdateProductRequest request,
            ISender sender) =>
        {
            var result = await sender.Send(new UpdateProductCommand(id, request));
            return Results.Ok(result);
        });
    }
}
