using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketsAPI.Infrastructure.Persistence.Repositories;

namespace TicketsAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(
        configuration.GetConnectionString("TicketsDB")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
        services.AddScoped<ITicketPriorityRepository, TicketPriorityRepository>();
        services.AddScoped<ITicketCategoryRepository, TicketCategoryRepository>();

        return services;
    }
}