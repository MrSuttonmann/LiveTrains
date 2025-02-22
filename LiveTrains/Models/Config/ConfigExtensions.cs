using LiveTrains.Models.Config;

namespace LiveTrains.Models.Config;

public static class ConfigExtensions
{
    public static IServiceCollection AddRailDataConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RailDataConfig>(configuration.GetSection("RailData"));
        return services;
    }
}