using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Solutions;

public class SolutionSuggestion
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Title { get; set; }
    public double Confidence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //entities lists
    public List<SolutionSuggestionStep> Steps { get; set; } = new();
    public List<SolutionSource> Sources { get; set; } = new();
}
