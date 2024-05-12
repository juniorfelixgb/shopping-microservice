using Catalog.Domain.Entities;
using Marten;
using Marten.Schema;

namespace Catalog.Infrastructure.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
        {
            return;
        }

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    public static IEnumerable<Product> GetPreconfiguredProducts()
        => new List<Product>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "This phone is the company's biggest change",
                ImageFile = "product-1.png", 
                Price = 950.00m,
                Category = new List<string>
                {
                    "Smart Phone"
                }
            }
        };
}
