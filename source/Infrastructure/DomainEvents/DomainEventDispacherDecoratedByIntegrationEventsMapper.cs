using BuildingBlocks.Application.DomainEvents;
using BuildingBlocks.Domain.DomainEvents;
using BuildingBlocks.Infrastructure.IntegrationEvents;

namespace BuildingBlocks.Infrastructure.DomainEvents
{
    internal sealed class DomainEventDispacherDecoratedByIntegrationEventsMapper : IDomainEventDispacher
    {
        private readonly IDomainEventDispacher _decoratedDomainEventDispacher;

        private readonly OutboxMessagesFactory _outboxMessagesFactory;

        private readonly IOutbox _outbox;

        public DomainEventDispacherDecoratedByIntegrationEventsMapper(
            IDomainEventDispacher decoratedDomainEventDispacher,
            OutboxMessagesFactory outboxMessagesFactory,
            IOutbox outbox)
        {
            _decoratedDomainEventDispacher = decoratedDomainEventDispacher;
            _outboxMessagesFactory = outboxMessagesFactory;
            _outbox = outbox;
        }

        public async Task Dispach(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            if (!domainEvents.Any())
            {
                return;
            }

            await _decoratedDomainEventDispacher.Dispach(domainEvents, cancellationToken);

            var outboxMessages = _outboxMessagesFactory.GetOutboxMessages(domainEvents);

            if(outboxMessages.Any())
            {
                await _outbox.Add(outboxMessages);
            }
        }
    }
}
