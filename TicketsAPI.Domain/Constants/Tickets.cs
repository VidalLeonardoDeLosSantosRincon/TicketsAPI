namespace TicketsAPI.Domain.Constants;

public static class Tickets
{
    public static class Status {
        public const string New = "new";
        public const string Classified = "classified";
        public const string Assigned = "assigned";
        public const string InProgress = "in_progress";
        public const string Resolved = "resolved";
        public const string Closed = "closed";
    }

    public static class Category
    {
        public const string Network = "network";
        public const string Hardware = "hardware";
        public const string Software = "software";
        public const string Access = "access";
        public const string Email = "email";
        public const string Security = "security";
        public const string Other = "other";
    }
}
