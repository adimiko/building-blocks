using BuildingBlocks.Domain.SystemClocks;

namespace BuildingBlocks.Domain.DomainEvents
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurrenceOn { get; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurrenceOn = SystemClock.UtcNow;
        }
    }
}