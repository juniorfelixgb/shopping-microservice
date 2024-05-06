using Carter;
using Catalog.Application.Products.GetProductById;
using MediatR;

namespace Catalog.Api.Endpoints;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (
            Guid id,
            ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            return Results.Ok(result);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
