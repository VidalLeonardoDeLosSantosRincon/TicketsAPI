using System.ComponentModel.DataAnnotations.Schema;

namespace TicketsAPI.Domain.Models.Solutions;

public class SolutionSource
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string? Label { get; set; }

    //foreignKeys
    public int SolutionSuggestionId { get; set; }

    [ForeignKey(nameof(SolutionSourceType))]
    public int SolutionSourceTypeId { get; set; }

    //entities
    public SolutionSourceType? SolutionSourceType { get; set; }
}
