using TicketsAPI.Application.DTOs.Access;

namespace TicketsAPI.Application.Interfaces.Controllers;

public interface IAuthController
{
    /// <summary>
    /// Genera un token de acceso en base a la información del usuario
    /// </summary>
    /// <param name="login">Este objeto de tipo <see cref="LoginResponseDto"/> contiene el correo y contraseña para generar el token de acceso</param>
    /// <returns>
    /// <para>Retorna un <see cref="Task{IActionResult}"/> de tipo <see cref="LoginResponseDto"/> con la información de la sessión,</para>
    /// <para>o de tipo <see langword="null"/> si falló</para>
    /// </returns>
    Task<IActionResult> Token(LoginDto login);
}
