using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsAPI.Domain.Models.Teams;

public class TeamMember
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //foreignKeys
    public int TeamId { get; set; }
}
