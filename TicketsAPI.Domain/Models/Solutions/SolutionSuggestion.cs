using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Solutions;

public class SolutionSuggestion
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public double Confidence { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //entities lists
    public List<SolutionSuggestionStep> Steps { get; set; } = new();
    public List<SolutionSource> Sources { get; set; } = new();
}
