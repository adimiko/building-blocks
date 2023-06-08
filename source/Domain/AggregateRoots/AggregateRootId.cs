using BuildingBlocks.Domain.Entities;

namespace BuildingBlocks.Domain.AggregateRoots
{
    public abstract record AggregateRootId : EntityId
    {
        protected AggregateRootId(Guid id)
            : base(id) { }
    }
}