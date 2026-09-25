using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketsAPI.Application.Interfaces.Services;
using TicketsAPI.Application.Services;

namespace TicketsAPI.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
    this IServiceCollection services)
    {
        // Mapster
        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        services.AddMapster();

        services.AddScoped<ITeamService, TeamService>();

        return services;
    }
}
