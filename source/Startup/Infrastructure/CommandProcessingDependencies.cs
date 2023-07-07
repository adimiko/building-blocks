using BuildingBlocks.Infrastructure.Commands.UnitOfWorks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Startup.Infrastructure
{
    internal static class CommandProcessingDependencies
    {
        internal static IServiceCollection AddCommandProcessingDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.Decorate(typeof(IRequestHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

            return services;
        }
    }
}
