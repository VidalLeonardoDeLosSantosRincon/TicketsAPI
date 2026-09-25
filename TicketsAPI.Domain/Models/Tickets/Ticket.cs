using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketsAPI.Domain.Models.Solutions;
using TicketsAPI.Domain.Models.Teams;

namespace TicketsAPI.Domain.Models.Tickets;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public string? Requester { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //foreignKeys
    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }

    [ForeignKey(nameof(Priority))]
    public int PriorityId { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(TeamMember))]
    public int TeamMemberId { get; set; }

    //[ForeignKey(nameof(Classification))]
    //public int ClassificationId { get; set; }

    //entities
    public TicketStatus? Status { get; set; }
    public TicketPriority? Priority { get; set; }
    public TicketCategory? Category { get; set; }
    public TeamMember? TeamMember { get; set; }
    public TicketClassification? Classification { get; set; }

    //entities lists
    public List<SolutionSuggestion> Suggestions { get; set; } = new();
    public List<TimelineEvent> TimelineEvents { get; set; } = new();
}
