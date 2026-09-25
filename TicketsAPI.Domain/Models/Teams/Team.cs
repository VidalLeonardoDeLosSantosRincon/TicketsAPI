using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Teams;

public class Team
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Label { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //entities lists
    public List<TeamMember> Members { get; set; } = new();
}
