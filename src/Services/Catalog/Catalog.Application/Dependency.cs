using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using FluentValidation;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application;

public static class Dependency
{
    public static Assembly CurrentAssembly = typeof(Dependency).Assembly;
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database")!;

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(CurrentAssembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(CurrentAssembly);

        services.AddMarten(options =>
            options.Connection(connectionString))
                .UseLightweightSessions();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddHealthChecks()
                .AddNpgSql(connectionString);

        return services;
    }
}
