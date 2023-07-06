using BuildingBlocks.Domain;
using BuildingBlocks.Domain.AggregateRoots;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Infrastructure.Repositories
{
    internal sealed class Repository<TAggregateRoot, TAggregateRootId> : IRepository<TAggregateRoot, TAggregateRootId>
        where TAggregateRoot : class, IAggregateRoot
        where TAggregateRootId : AggregateRootId
    {
        private readonly DbSet<TAggregateRoot> _aggregateRoots;

        public Repository(DbContext dbContext) 
        {
            _aggregateRoots = dbContext.Set<TAggregateRoot>();
        }

        public Task Add(TAggregateRoot aggregateRoot)
        {
            return _aggregateRoots.AddAsync(aggregateRoot).AsTask();
        }

        public Task<TAggregateRoot?> Get(TAggregateRootId id)
        {
            return _aggregateRoots.FindAsync(id).AsTask();
        }
    }
}
