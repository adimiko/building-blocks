using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventPublicationIsNotDefinedException<TDomainEvent> : BuildingBlocksApplicationException
        where TDomainEvent : DomainEvent
    {
        public DomainEventPublicationIsNotDefinedException()
            : base($"Domain event publication is not defined ('{typeof(TDomainEvent)}')") { }
    }
}
