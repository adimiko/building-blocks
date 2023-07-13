using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    public abstract record IntegrationEvent<TDomainEvent> : IIntegrationEvent
        where TDomainEvent : DomainEvent
    { 
        public Guid IntegrationEventId { get; }

        public DateTime OccurredOn { get; }

        protected IntegrationEvent(TDomainEvent domainEvent)
        {
            IntegrationEventId = domainEvent.DomainEventId;
            OccurredOn = domainEvent.OccurrenceOn;
        }
    }
}
