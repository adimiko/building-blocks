namespace BuildingBlocks.Domain.DomainEvents
{
    internal sealed class DomainEventCannotBeNullException<TDomainEvent> : BuildingBlocksDomainException
        where TDomainEvent : DomainEvent
    {
        internal DomainEventCannotBeNullException()
            : base($"{typeof(TDomainEvent)} cannot be null") { }
    }
}