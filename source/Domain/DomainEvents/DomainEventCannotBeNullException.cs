namespace BuildingBlocks.Domain.DomainEvents
{
    public sealed class DomainEventCannotBeNullException<TDomainEvent> : BuildingBlocksDomainException
        where TDomainEvent : DomainEvent
    {
        internal DomainEventCannotBeNullException()
            : base($"{typeof(TDomainEvent)} cannot be null") { }
    }
}