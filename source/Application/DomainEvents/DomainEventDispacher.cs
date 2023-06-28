using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventDispacher : IDomainEventDispacher
    {
        private readonly IDomainEventPublisher _domainEventPublisher;

        public DomainEventDispacher(IDomainEventPublisher domainEventPublisher)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public async Task Dispach(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _domainEventPublisher.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
