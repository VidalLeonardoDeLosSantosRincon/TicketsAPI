using System.Text.Json.Serialization;

namespace TicketsAPI.Application.DTOs.Teams;

public class TeamDto
{
    [JsonPropertyName("id")]
    public string? Code { get; set; }
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    [JsonPropertyName("slug")]
    public string? Label { get; set; }
    public string? Description { get; set; }
    public int MemberCount { get; set; }
    public int OpenTickets { get; set; }
    public List<TeamMemberDto> Members { get; set; } = new();
}
