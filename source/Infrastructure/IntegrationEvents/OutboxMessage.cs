namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    internal sealed record OutboxMessage
    {
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required string Data { get; init; }

        public required DateTime OccurredOn { get; init; }
    }
}
