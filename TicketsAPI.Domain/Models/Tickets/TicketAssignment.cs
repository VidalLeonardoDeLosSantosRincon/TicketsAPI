using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Domain.Models.Tickets;

public class TicketAssignment
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public int Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //foreignKeys
    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }

    [ForeignKey(nameof(TeamMember))]
    public int TeamMemberId { get; set; }

    //entities
    public Ticket? Ticket { get; set; }
    public TeamMember? TeamMember { get; set; }
}
