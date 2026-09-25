namespace TicketsAPI.Domain.Models;

public class TimelineEvent
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public DateTime? At { get; set; }
    public string? Label { get; set; }
    public string? Detail { get; set; }
}