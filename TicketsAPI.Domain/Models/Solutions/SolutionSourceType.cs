using System.ComponentModel.DataAnnotations;

namespace TicketsAPI.Domain.Models.Solutions;

public class SolutionSourceType
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}
