using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal interface IDomainEventsAccessor
    {
        IReadOnlyCollection<DomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}
