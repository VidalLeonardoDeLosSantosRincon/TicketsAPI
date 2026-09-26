using TicketsAPI.Application.DTOs.Users;

namespace TicketsAPI.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDto?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);
    Task<UserDto?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
