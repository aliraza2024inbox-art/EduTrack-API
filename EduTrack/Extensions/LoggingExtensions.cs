using Microsoft.Extensions.Logging;

namespace EduTrack.Api.Extensions;

public static class LoggingExtensions
{
    public static IServiceCollection AddApplicationLogging(
        this IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.ClearProviders();

            builder.AddConsole();

            builder.AddDebug();
        });

        return services;
    }
}