namespace TicketsAPI.Application.DTOs.Users;

public class RoleDto
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Description { get; set; }
}
