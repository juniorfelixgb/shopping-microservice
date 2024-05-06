using Carter;
using Catalog.Application.Products.CreateProduct;
using Mapster;
using MediatR;

namespace Catalog.Api.Endpoints;
public partial class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (
            CreateProductCommand request,
            ISender sender) =>
        {
            var result = await sender.Send(request);

            return Results.Created($"/products/{result.Id}", result);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
