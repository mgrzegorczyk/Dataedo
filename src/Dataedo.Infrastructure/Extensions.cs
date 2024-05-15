using Dataedo.Infrastructure.Repositories;
using Dataedo.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dataedo.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        var inMemoryDatabaseName = "myDB";

        serviceCollection.AddDbContext<AppDbContext>(opt =>
            opt.UseInMemoryDatabase(inMemoryDatabaseName));

        serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
        
        var dbContext = serviceCollection
            .BuildServiceProvider()
            .GetService<AppDbContext>();

        if (dbContext != null) UsersInitializer.Seed(dbContext);

        return serviceCollection;
    }
}