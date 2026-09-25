namespace TicketsAPI.Application.DTOs.Tickets;

public class TicketSummaryDto
{
    public int OpenTicketsCount { get; set; }
    public int CriticalTicketsCount { get; set; }
    public int InProgressTicketsCount { get; set; }
    public int ResolvedTicketsCount { get; set; }
    public IEnumerable<TicketDto>? Tickets { get; set; }
}
