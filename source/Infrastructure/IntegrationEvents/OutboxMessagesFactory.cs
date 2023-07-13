using BuildingBlocks.Domain.DomainEvents;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;

namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    internal sealed class OutboxMessagesFactory
    {
        private readonly Assembly _infrastructureLayer;

        private readonly IImmutableDictionary<Type, Type> _integrationEventTypes;

        public OutboxMessagesFactory(Assembly infrastructureLayer)
        {
            _infrastructureLayer = infrastructureLayer;

            _integrationEventTypes = _infrastructureLayer
            .GetTypes()
            .Where(x => x.BaseType != null && x.BaseType.IsGenericType && x.BaseType.GetGenericTypeDefinition() == typeof(IntegrationEvent<>))
            .ToImmutableDictionary(x => x.BaseType.GenericTypeArguments[0]);
        }

        internal IEnumerable<OutboxMessage> GetOutboxMessages(IEnumerable<DomainEvent> domainEvents)
        {
            // zastanowić się czy nie zapiąć się na publishera z dekoratorem
            // zastanowić się czy może nie inaczej
            List<IIntegrationEvent> integrationEvents = new List<IIntegrationEvent>();

            foreach (var domainEvent in domainEvents)
            {
                if(_integrationEventTypes.TryGetValue(domainEvent.GetType(), out Type integrationEventType))
                {
                    var integrationEvent = (IIntegrationEvent)Activator.CreateInstance(integrationEventType, domainEvent); //TODO performance

                    integrationEvents.Add(integrationEvent);
                }
            }

            var outboxMessages = integrationEvents.Select(i => new OutboxMessage()
            {
                Id = i.IntegrationEventId,
                Name = i.GetType().Name,
                Data = JsonSerializer.Serialize(i),
                OccurredOn = i.OccurredOn,
            });

            return outboxMessages;
        }
    }
}
