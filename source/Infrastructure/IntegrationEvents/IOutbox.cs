namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    internal interface IOutbox
    {
        Task Add(IEnumerable<OutboxMessage> outboxMessages);
    }
}
