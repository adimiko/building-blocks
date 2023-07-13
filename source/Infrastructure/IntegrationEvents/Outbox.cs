using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.IntegrationEvents
{
    internal sealed class Outbox : IOutbox
    {
        private readonly DbSet<OutboxMessage> _outboxMessages;

        public Outbox(DbContextBase dbContext)
        {
            _outboxMessages = dbContext.Set<OutboxMessage>();
        }

        public Task Add(IEnumerable<OutboxMessage> outboxMessages)
        {
            return _outboxMessages.AddRangeAsync(outboxMessages);
        }
    }
}
