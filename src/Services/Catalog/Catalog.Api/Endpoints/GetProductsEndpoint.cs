using Carter;
using Catalog.Application.Products.GetProducts;
using MediatR;

namespace Catalog.Api.Endpoints
{
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (
                [AsParameters] GetProductsRequest request,
                ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery(request));
                return Results.Ok(result);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}
