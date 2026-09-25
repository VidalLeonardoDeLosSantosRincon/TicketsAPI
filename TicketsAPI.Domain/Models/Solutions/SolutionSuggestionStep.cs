using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsAPI.Domain.Models.Solutions;

public class SolutionSuggestionStep
{
    [Key]
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //foreignKeys
    public int SolutionSuggestionId { get; set; }
}
