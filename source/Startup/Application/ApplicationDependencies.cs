﻿using BuildingBlocks.Application.DomainEvents;
using BuildingBlocks.Application.InternalCommands;
using BuildingBlocks.Infrastructure.DomainEvents;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Startup.Application
{
    internal static class ApplicationDependencies
    {
        internal static IServiceCollection AddApplicationDependencies(this IServiceCollection services, Assembly applicationLayer)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationLayer));

            services.AddTransient<IDomainEventDispacher, DomainEventDispacher>();
            services.AddTransient<IDomainEventPublisher, DomainEventPublisher>();
            services.AddTransient<IDomainEventsAccessor, DomainEventsAccessor>();

            services.Decorate(typeof(IRequestHandler<>), typeof(InternalCommandHandlerDecoratorWithDomainEventDispacher<>));

            services.Scan(scan => scan
              .FromAssemblies(applicationLayer)
              .AddClasses(c => c.AssignableTo(typeof(IDomainEventPublication<>)))
              .AsImplementedInterfaces()
              .WithTransientLifetime());

            return services;
        }
    }
}
