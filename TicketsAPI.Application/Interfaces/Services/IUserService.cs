using TicketsAPI.Application.DTOs.Users;

namespace TicketsAPI.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserDto?> GetByGuid(Guid guid);
    Task<UserDto?> GetByEmail(string email);
}
