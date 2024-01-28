﻿namespace DentallApp.Features;

public static class FeatureServicesExtensions
{
    public static IServiceCollection AddFeatureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IAvailabilityQueries, AvailabilityQueries>();

        return services;
    }
}
