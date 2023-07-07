using BuildingBlocks.Domain.SystemClocks;

namespace BuildingBlocks.Domain.DomainEvents
{
    public abstract record DomainEvent : IDomainEvent
    {
        public Guid DomainEventId { get; }

        public DateTime OccurrenceOn { get; }

        public DomainEvent()
        {
            DomainEventId = Guid.NewGuid();
            OccurrenceOn = SystemClock.UtcNow;
        }
    }
}