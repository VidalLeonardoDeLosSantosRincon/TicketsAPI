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

    public async Task<UserDto?> GetByGuidAsync(Guid guid)
    {
        var user = await _userRepository.GetByGuidAsync(guid);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }
}
