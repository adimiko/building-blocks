using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Startup
{
    internal static class ApplicationDependencies
    {
        internal static IServiceCollection AddApplicationDependencies(this IServiceCollection services, Assembly applicationLayer)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationLayer));

            return services;
        }
    }
}
