using System.Threading;
using TicketsAPI.Application.DTOs.Users;

namespace TicketsAPI.Application.Services;

public class UserService: IUserService
{
    public readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByGuidAsync(guid, cancellationToken);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }

    public async Task<UserDto?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (user is null) return null;

        return user.Adapt<UserDto>();
    }
}
