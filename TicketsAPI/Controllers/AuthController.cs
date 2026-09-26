using TicketsAPI.Application.DTOs.Access;
using TicketsAPI.Application.Interfaces.Controllers;
using TicketsAPI.Application.Interfaces.Services.Auth;

namespace TicketsAPI.Controllers;

[Route("api/auth")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase, IAuthController
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("token")]
    public async Task<IActionResult> Token([FromBody] LoginDto login, CancellationToken cancellationToken)
    {
        try
        {
            var accessToken = await _jwtService.GenerateTokenAsync(login, cancellationToken);
            return Ok(accessToken);
        } catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        } catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocurrió un error inesperado.", details = ex.Message });
        }
    }
}
