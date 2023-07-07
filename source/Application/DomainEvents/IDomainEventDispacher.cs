using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal interface IDomainEventDispacher
    {
        Task Dispach(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken);
    }
}
