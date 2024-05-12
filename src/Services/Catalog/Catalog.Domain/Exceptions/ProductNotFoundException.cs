using BuildingBlocks.Exceptions;

namespace Catalog.Domain.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId)
        : base("Product", productId)
    {
        
    }
}
