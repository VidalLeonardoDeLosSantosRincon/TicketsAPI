using TicketsAPI.Application.DTOs.Access;
using TicketsAPI.Application.Interfaces.Services.Auth;
using TicketsAPI.Interfaces.Controllers.V1;

namespace TicketsAPI.Controllers.V1;

[Route("api/v{version:apiVersion}/auth")]
[ApiVersion("1.0")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase, IAuthController
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    // POST: api/v1/auth/token
    [HttpPost("token")]
    public async Task<IActionResult> Token([FromBody] LoginDto login, CancellationToken cancellationToken)
    {
        try
        {
            var accessToken = await _jwtService.GenerateTokenAsync(login, cancellationToken);
            return Ok(accessToken);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocurrió un error inesperado.", details = ex.Message });
        }
    }
}
