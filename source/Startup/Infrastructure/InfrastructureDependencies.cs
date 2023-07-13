using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BuildingBlocks.Domain;
using BuildingBlocks.Infrastructure.Repositories;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Infrastructure.IntegrationEvents;
using BuildingBlocks.Application.DomainEvents;
using BuildingBlocks.Infrastructure.DomainEvents;

namespace BuildingBlocks.Startup.Infrastructure
{
    internal static class InfrastructureDependencies
    {
        internal static IServiceCollection AddInfrastructureDependencies<TContext>(
            this IServiceCollection services,
            Assembly infrastructureLayer,
            Action<DbContextOptionsBuilder> optionsAction,
            int poolSize = 1024)
            where TContext : DbContextBase
        {
            // Data
            services.AddDbContextPool<TContext>(optionsAction, poolSize);
            
            services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<TContext>()));
            services.AddScoped((Func<IServiceProvider, DbContextBase>)(sp => sp.GetRequiredService<TContext>()));

            services.Scan(scan => scan
              .FromAssemblies(infrastructureLayer)
              .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
              .AsImplementedInterfaces()
              .WithScopedLifetime());

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<IOutbox, Outbox>();
            services.AddSingleton(new OutboxMessagesFactory(infrastructureLayer));

            services.Decorate<IDomainEventDispacher, DomainEventDispacherDecoratedByIntegrationEventsMapper>();

            services.AddCommandProcessingDependencies();

            return services;
        }
    }
}
