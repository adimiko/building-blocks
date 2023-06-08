namespace BuildingBlocks.Domain.AggregateRoots
{
    public interface IAggregateRoot 
    {
        public AggregateRootVersion Version { get; }
    }
}