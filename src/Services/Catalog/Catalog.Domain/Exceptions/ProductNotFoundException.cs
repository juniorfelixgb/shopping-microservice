namespace Catalog.Domain.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string productId)
        : base($"Product with Id: {productId} not found!")
    {
        
    }
}
