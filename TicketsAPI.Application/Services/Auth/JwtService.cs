using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketsAPI.Application.DTOs.Access;
using TicketsAPI.Application.DTOs.Users;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Application.Interfaces.Services.Auth;
using TicketsAPI.Domain.Constants;

namespace TicketsAPI.Application.Services.Auth;

public class JwtService: IJwtService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    public JwtService(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    private async Task<UserDto> CheckUser(LoginDto login)
    {
        var email = login.Email ?? string.Empty;
        var credenticialsMessage = "usuario o contraseña invalido";

        var user = await _userService.GetByEmail(email) ?? throw new UnauthorizedAccessException(credenticialsMessage);
      
        if (user?.Role is null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            throw new UnauthorizedAccessException(credenticialsMessage);
        }

        return user;
    }

    public async Task<LoginResponseDto> GenerateToken(LoginDto login)
    {
        var user = await CheckUser(login);

        var userId = user.Guid.ToString();
        var userName = user.Email ?? string.Empty;
        var role = user.Role?.Name ?? string.Empty;

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role),
            new Claim("scope", Policies.Scopes.GrantTicketAccess),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var secret = _configuration["Authentication:JWT:Secret"] ?? string.Empty;
        if (string.IsNullOrWhiteSpace(secret)) throw new InvalidDataException("Invalid Client Secret");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Authentication:JWT:Issuer"],
            audience: _configuration["Authentication:JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        var accessToken = new LoginResponseDto()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token)
        };

        return accessToken;
    }
}
