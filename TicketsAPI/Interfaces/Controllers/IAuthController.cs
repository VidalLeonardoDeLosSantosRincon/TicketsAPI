using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.DTOs.Access;

namespace TicketsAPI.Application.Interfaces.Controllers;

public interface IAuthController
{
    Task<IActionResult> Token(LoginDto login);
}
