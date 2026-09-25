using System.Text.Json.Serialization;

namespace TicketsAPI.Application.DTOs.Users;

public class UserDto
{
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    [JsonIgnore]
    public string? Password { get; set; }
    public RoleDto? Role { get; set; }
}
