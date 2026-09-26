using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
