using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.DTOs.Access;
using TicketsAPI.Application.Interfaces.Services.Auth;

namespace TicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto login)
        {
            try
            {
                var accessToken = await _jwtService.GenerateToken(login);
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
}
