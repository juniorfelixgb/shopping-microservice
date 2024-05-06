using Catalog.Domain.Entities;

namespace Catalog.Application.Products.GetProducts;

public record GetProductsResponse(IReadOnlyList<Product>? Products);
