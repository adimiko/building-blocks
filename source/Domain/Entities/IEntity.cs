using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Domain.Entities
{
    public interface IEntity
    {
        IReadOnlyCollection<DomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}