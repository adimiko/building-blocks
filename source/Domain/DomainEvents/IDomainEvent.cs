namespace BuildingBlocks.Domain.DomainEvents
{
    public interface IDomainEvent
    {
        public Guid DomainEventId { get; }

        public DateTime OccurrenceOn { get; }
    }
}