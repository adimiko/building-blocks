using BuildingBlocks.Domain.DomainEvents;
using MediatR;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventPublisher : IDomainEventPublisher
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
            var domainEventType = domainEvent.GetType();

            var domainEventPublicationType = typeof(IDomainEventPublication<>).MakeGenericType(domainEventType);

            dynamic? domainEventPublication = _serviceProvider.GetService(domainEventPublicationType);

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
