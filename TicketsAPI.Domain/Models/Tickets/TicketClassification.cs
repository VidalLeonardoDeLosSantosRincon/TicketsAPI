namespace TicketsAPI.Domain.Models.Tickets;

public class TicketClassification
{
    public double Confidence { get; set; }
    public string? Rationale { get; set; }
}