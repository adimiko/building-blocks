using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Application.DomainEvents
{
    internal sealed class DomainEventDispacher
    {
        private readonly DomainEventPublisher _domainEventPublisher;

        public DomainEventDispacher(DomainEventPublisher domainEventPublisher)
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
