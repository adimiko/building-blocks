using BuildingBlocks.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Startup.Domain
{
    internal static class DomainDependencies
    {
        internal static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<AggregateRootExistsCheckerDomainService>();

            return services;
        }
    }
}
