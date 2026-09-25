using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Tickets;

public class TicketPriority
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
