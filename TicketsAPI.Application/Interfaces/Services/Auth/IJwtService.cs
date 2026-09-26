using TicketsAPI.Application.DTOs.Access;

namespace TicketsAPI.Application.Interfaces.Services.Auth;

public interface IJwtService
{
    Task<LoginResponseDto> GenerateTokenAsync(LoginDto login);
}
