namespace BuildingBlocks.Domain.DomainEvents
{
    public interface IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurrenceOn { get; }
    }
}