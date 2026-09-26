using Microsoft.EntityFrameworkCore;
using TicketsAPI.Domain.Interfaces.Repositories;
using TicketsAPI.Domain.Models.Users;
using TicketsAPI.Infrastructure.Persistence.Database;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByGuidAsync(Guid guid)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Guid == guid);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => 
                !string.IsNullOrWhiteSpace(x.Email)
                && x.Email.ToLower() == email.ToLower()
            );
    }
}
