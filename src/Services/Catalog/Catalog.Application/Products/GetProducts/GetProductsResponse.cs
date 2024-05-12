using Catalog.Domain.Entities;
using Marten.Pagination;

namespace Catalog.Application.Products.GetProducts;

public record GetProductsResponse(IPagedList<Product>? Products);
