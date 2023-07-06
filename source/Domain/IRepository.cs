using BuildingBlocks.Domain.AggregateRoots;

namespace BuildingBlocks.Domain
{
    public interface IRepository<TAggregateRoot, TAggregateRootId>
        where TAggregateRoot : IAggregateRoot
        where TAggregateRootId : AggregateRootId
    {
        Task Add(TAggregateRoot aggregateRoot);

        Task<TAggregateRoot?> Get(TAggregateRootId id);
    }
}
