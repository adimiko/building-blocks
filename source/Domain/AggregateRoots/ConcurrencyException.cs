namespace BuildingBlocks.Domain.AggregateRoots
{
    public sealed class ConcurrencyException : BuildingBlocksDomainException
    {
        internal ConcurrencyException(string message)
            : base(message) { }
    }
}