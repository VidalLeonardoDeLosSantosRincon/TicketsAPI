using System.Runtime.Serialization;

namespace TicketsAPI.Domain.Enums;

public enum TicketStatusEnum
{
    [EnumMember(Value = "new")]
    New,

    [EnumMember(Value = "classified")]
    Classified,

    [EnumMember(Value = "assigned")]
    Assigned,

    [EnumMember(Value = "in_progress")]
    InProgress,

    [EnumMember(Value = "resolved")]
    Resolved,

    [EnumMember(Value = "closed")]
    Closed
}
