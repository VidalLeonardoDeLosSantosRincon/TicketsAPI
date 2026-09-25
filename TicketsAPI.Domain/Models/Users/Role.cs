using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Users;

public class Role
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Active { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
