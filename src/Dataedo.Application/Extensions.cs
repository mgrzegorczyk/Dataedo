using Microsoft.Extensions.DependencyInjection;

namespace Dataedo.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Extensions).Assembly));
    }    
}