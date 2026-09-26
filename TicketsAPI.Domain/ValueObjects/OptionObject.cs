namespace TicketsAPI.Domain.ValueObjects;

public class OptionObject
{
    public Guid Guid { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
}
