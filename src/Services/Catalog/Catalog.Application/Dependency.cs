using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class Dependency
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblies(typeof(Dependency).Assembly));

        services.AddMarten(options =>
            options.Connection(configuration.GetConnectionString("Database")!))
                .UseLightweightSessions();

        return services;
    }
}
