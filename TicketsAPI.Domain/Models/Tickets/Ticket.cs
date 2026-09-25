using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketsAPI.Domain.Models.Solutions;
using TicketsAPI.Domain.Models.Teams;
using TicketsAPI.Domain.Models.Users;

namespace TicketsAPI.Domain.Models.Tickets;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //foreignKeys
    [ForeignKey(nameof(Status))]
    public int StatusId { get; set; }

    [ForeignKey(nameof(Priority))]
    public int PriorityId { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    //[ForeignKey(nameof(Classification))]
    //public int ClassificationId { get; set; }

    //entities
    public TicketStatus? Status { get; set; }
    public TicketPriority? Priority { get; set; }
    public TicketCategory? Category { get; set; }
    //public TeamMember? TeamMember { get; set; }
    public User? User { get; set; }
    //public TicketClassification? Classification { get; set; }

    //entities lists
    public List<SolutionSuggestion> Suggestions { get; set; } = new();
    public List<TimelineEvent> TimelineEvents { get; set; } = new();
}
