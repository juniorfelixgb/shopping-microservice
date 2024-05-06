namespace Catalog.Application.Products.UpdateProduct;

public class UpdateProductRequest
{
    public string? Name { get; set; }
    public List<string> Category { get; set; } = [];
    public string? Description { get; set; }
    public string? ImageFile { get; set; }
    public decimal Price { get; set; }
}
