namespace TicketsAPI.Application.DTOs.Access;

public class LoginResponseDto
{
    public Guid Code { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
    public string? AccessToken { get; set; }
    public DateTime? ExperitationDate { get; set; }
}
