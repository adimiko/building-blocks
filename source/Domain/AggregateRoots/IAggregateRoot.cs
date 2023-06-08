using BuildingBlocks.Domain.Entities;

namespace BuildingBlocks.Domain.AggregateRoots
{
    public interface IAggregateRoot : IEntity
    {
        public AggregateRootVersion Version { get; }
    }
}