using System.Threading;
using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Infrastructure.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => 
                !string.IsNullOrWhiteSpace(x.Email)
                && x.Email.ToLower() == email.ToLower()
            , cancellationToken);
    }
}
