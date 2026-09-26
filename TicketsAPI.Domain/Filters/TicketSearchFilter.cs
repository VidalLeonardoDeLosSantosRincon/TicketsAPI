namespace TicketsAPI.Domain.Filters;

public class TicketSearchFilter
{
    public bool? Summary { get; set; } = false;
    public string? SeachTerm { get; set; }
    public Guid Status { get; set; }
    public Guid Priority { get; set; }
    public Guid Category { get; set; }
    public Guid Team { get; set; }
    public int? CurrentPage { get; set; }
    public int? PageSize { get; set; }
}
