using Microsoft.Extensions.DependencyInjection;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Application.Services;

namespace TicketsAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
    this IServiceCollection services)
    {
        services.AddScoped<ITeamService, TeamService>();

        return services;
    }
}