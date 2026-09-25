using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketsAPI.Domain.Models.Teams;
using TicketsAPI.Domain.Models.Users;
using System.Text.Json.Serialization;

namespace TicketsAPI.Application.DTOs.Tickets;

public class TicketDto
{
    [JsonPropertyName("id")]
    public string? Code { get; set; }

    [JsonPropertyName("number")]
    public int Id { get; set; }

    public Guid Guid { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }

    public string? Status { get; set; }
    public string? StatusLabel { get; set; }
    public string? Priority { get; set; }
    public string? PriorityLabel { get; set; }
    public string? Category { get; set; }
    public string? CategoryLabel { get; set; }

    [JsonPropertyName("teamId")]
    public string? TeamCode { get; set; }

    public string? Assignee { get; set; }
    public string? Requester { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
