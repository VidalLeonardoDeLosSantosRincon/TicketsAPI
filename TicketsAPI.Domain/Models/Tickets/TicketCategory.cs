using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Tickets;

public class TicketCategory
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
