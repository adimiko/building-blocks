using BuildingBlocks.Application.DomainEvents;
using BuildingBlocks.Domain.DomainEvents;

namespace BuildingBlocks.Infrastructure.DomainEvents
{
    internal sealed class DomainEventDispacherDecoratedByIntegrationEventsMapper : IDomainEventDispacher
    {
        private readonly IDomainEventDispacher _decoratedDomainEventDispacher;

        public DomainEventDispacherDecoratedByIntegrationEventsMapper(IDomainEventDispacher decoratedDomainEventDispacher)
        {
            _decoratedDomainEventDispacher = decoratedDomainEventDispacher;
        }

        public async Task Dispach(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            await _decoratedDomainEventDispacher.Dispach(domainEvents, cancellationToken);

            //TODO covenrt domain event to integration event and then publish using ef core to save in outbox
        }
    }
}
