using Mapster;
using TicketsAPI.Application.DTOs.Users;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Domain.Interfaces.Repositories;

namespace TicketsAPI.Application.Services;

public class UserService: IUserService
{
    public readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetByGuid(Guid guid)
    {
        var user = await _userRepository.GetByGuid(guid);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }

    public async Task<UserDto?> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }
}
