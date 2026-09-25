namespace TicketsAPI.Application.DTOs.Teams;

public class TeamMemberDto
{
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}
