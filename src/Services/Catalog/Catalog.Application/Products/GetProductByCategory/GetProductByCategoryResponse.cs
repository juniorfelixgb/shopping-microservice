using Catalog.Domain.Entities;

namespace Catalog.Application.Products.GetProductByCategory;

public record GetProductByCategoryResponse(IReadOnlyList<Product> Products);
