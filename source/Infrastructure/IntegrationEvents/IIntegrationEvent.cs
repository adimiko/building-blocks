namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    internal interface IIntegrationEvent
    {
        Guid IntegrationEventId { get; }

        DateTime OccurredOn { get; }
    }
}
