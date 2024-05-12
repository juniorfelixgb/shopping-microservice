namespace Catalog.Application.Products.GetProducts;

public record GetProductsRequest(int? PageNo = 1, int? PageSize = 10);