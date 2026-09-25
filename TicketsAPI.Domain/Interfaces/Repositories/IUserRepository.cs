using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByGuid(Guid guid);
    Task<User?> GetByEmail(string email);
}
