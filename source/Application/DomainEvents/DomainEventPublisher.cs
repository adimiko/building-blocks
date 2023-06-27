using BuildingBlocks.Domain.DomainEvents;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventPublisher
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public DomainEventPublisher(
            IMediator mediator,
            IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken)
            where TDomainEvent : DomainEvent
        {
            var domainEventPublication = _serviceProvider.GetService<DomainEventPublication<TDomainEvent>>();

            if (domainEventPublication is null) 
            {
                throw new DomainEventPublicationIsNotDefinedException<TDomainEvent>();
            }

            var internalCommands = domainEventPublication.GetInternalCommands(domainEvent);

            foreach (var internalCommand in internalCommands) 
            {
                await _mediator.Send(internalCommand, cancellationToken);
            }
        }
    }
}
