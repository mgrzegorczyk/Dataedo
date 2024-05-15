using Dataedo.Domain;

namespace Dataedo.Infrastructure.Seed;

public static class UsersInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        context.Users.AddRange(
            User.Create("Bob"),
            User.Create("Fred"),
            User.Create("Marcin")
        );
        context.SaveChanges();
    }
}