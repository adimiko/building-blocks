using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BuildingBlocks.Startup.Infrastructure
{
    internal static class InfrastructureDependencies
    {
        internal static IServiceCollection AddInfrastructureDependencies<TContext>(
            this IServiceCollection services,
            Assembly infrastructureLayer,
            Action<DbContextOptionsBuilder> optionsAction,
            int poolSize = DbContextPool<DbContext>.DefaultPoolSize)
            where TContext : DbContext
        {
            // Data
            services.AddDbContextPool<TContext>(optionsAction, poolSize);
            services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<TContext>()));

            services.Scan(scan => scan
              .FromAssemblies(infrastructureLayer)
              .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
              .AsImplementedInterfaces()
              .WithScopedLifetime());

            services.AddCommandProcessingDependencies();

            return services;
        }
    }
}
