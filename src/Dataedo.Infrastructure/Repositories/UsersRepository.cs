using Dataedo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dataedo.Infrastructure.Repositories;

public interface IUsersRepository
{
    Task<User?> GetByIdAsync(Guid userId);
    Task DeleteAsync(Guid userId);
    Task<List<User>> GetAll();
}

public class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _context;

    public UsersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        if (user is null || !user.IsActive) return;
        user.SetActivation(false);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAll()
    {
        return await _context.Users
            .ToListAsync();
    }
}