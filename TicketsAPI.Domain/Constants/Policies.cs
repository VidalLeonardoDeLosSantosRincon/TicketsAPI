namespace TicketsAPI.Domain.Constants;

public static class Policies
{
    public static class Cors
    {
        public const string DefaultPolicy = "DefaultPolicy";
    }

    public static class Scopes
    {
        public const string GrantTicketAccess = "grant.tickets.access";
    }
}
