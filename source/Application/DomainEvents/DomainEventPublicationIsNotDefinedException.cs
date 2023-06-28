using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventPublicationIsNotDefinedException<TDomainEvent> : BuildingBlocksApplicationException
        where TDomainEvent : DomainEvent
    {
        internal DomainEventPublicationIsNotDefinedException() //TODO poprawić aby było wiadomo jaki typ, może musi to być interface ??
            : base($"Domain event publication is not defined ('{typeof(TDomainEvent)}')") { }
    }
}
